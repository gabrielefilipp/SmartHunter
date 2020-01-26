using SmartHunter.Core.Helpers;
using SmartHunter.Game.Data;
using SmartHunter.Game.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;

namespace SmartHunter.Game.Helpers
{
    public static class MhwHelper
    {
        public static bool TryParseHex(string hexString, out long hexNumber)
        {
            return long.TryParse(hexString, NumberStyles.HexNumber, CultureInfo.InvariantCulture, out hexNumber);
        }

        public static ulong AddOffset(ulong address, long offset)
        {
            return (ulong)((long)address + offset);
        }

        // TODO: Wouldn't it be nice if all this were data driven?
        public static class DataOffsets
        {
            public static class Monster
            {
                // Doubly linked list
                public static readonly ulong MonsterStartOfStructOffset = 0x40;
                public static readonly ulong NextMonsterOffset = 0x18;
                public static readonly ulong MonsterHealthComponentOffset = 0x7670;
                public static readonly ulong PreviousMonsterOffset = 0x10;
                public static readonly ulong SizeScale = 0x180;
                public static readonly ulong PartCollection = 0x14528;
                public static readonly ulong RemovablePartCollection = PartCollection + 0x1ED0;
                public static readonly ulong StatusEffectCollection = 0x19900;
            }

            public static class MonsterModel
            {
                public static readonly int IdLength = 32; // 64?
                public static readonly ulong IdOffset = 0x179;
            }

            public static class MonsterHealthComponent
            {
                public static readonly ulong MaxHealth = 0x60;
                public static readonly ulong CurrentHealth = 0x64;
            }

            public static class MonsterPartCollection
            {
                public static readonly int MaxItemCount = 16;
                public static readonly ulong FirstPart = 0x50;
            }

            public static class MonsterPart
            {
                public static readonly ulong MaxHealth = 0x0C;
                public static readonly ulong CurrentHealth = 0x10;
                public static readonly ulong TimesBrokenCount = 0x18;
                public static readonly ulong NextPart = 0x1F8;//0x3F0;
            }

            public static class MonsterRemovablePartCollection
            {
                public static readonly int MaxItemCount = 32;
                public static readonly ulong FirstRemovablePart = 0x08;
            }

            public static class MonsterRemovablePart
            {
                public static readonly ulong MaxHealth = 0x0C;
                public static readonly ulong CurrentHealth = 0x10;
                public static readonly ulong Validity1 = 0x14;
                public static readonly ulong TimesBrokenCount = 0x18;
                public static readonly ulong Validity2 = 0x28;
                public static readonly ulong Validity3 = 0x40;
                public static readonly ulong NextRemovablePart = 0x78;
            }

            public static class MonsterStatusEffectCollection
            {
                public static int MaxItemCount = 20;
                public static ulong NextStatusEffectPtr = 0x08;
            }

            public static class MonsterStatusEffect
            {
                public static readonly ulong Id = 0x158;
                public static readonly ulong MaxDuration = 0x15C;
                public static readonly ulong CurrentBuildup = 0x178;
                public static readonly ulong MaxBuildup = 0x17C;
                public static readonly ulong CurrentDuration = 0x1A4;
                public static readonly ulong TimesActivatedCount = 0x1A8;
            }

            public static class PlayerNameCollection
            {
                public static readonly int PlayerNameLength = 32 + 1; // +1 for null terminator
                public static readonly ulong FirstPlayerName = 0x526AD;//0x54A45; //0x526AD OR 0x54238
            }

            public static class PlayerDamageCollection
            {
                public static readonly int MaxPlayerCount = 4;
                public static readonly ulong FirstPlayerPtr = 0x48;
                public static readonly ulong NextPlayerPtr = 0x58;
            }

            public static class PlayerDamage
            {
                public static readonly ulong Damage = 0x48;
            }
        }

        public static void UpdatePlayerWidget(Process process, ulong baseAddress, ulong equipmentAddress, ulong weaponAddress)
        {
            for (int index = 0; index < ConfigHelper.PlayerData.Values.StatusEffects.Length; ++index)
            {
                var statusEffectConfig = ConfigHelper.PlayerData.Values.StatusEffects[index];

                ulong sourceAddress = baseAddress;
                if (statusEffectConfig.Source == Config.StatusEffectConfig.MemorySource.Equipment)
                {
                    sourceAddress = equipmentAddress;
                }
                else if (statusEffectConfig.Source == Config.StatusEffectConfig.MemorySource.Weapon)
                {
                    sourceAddress = weaponAddress;
                }
                
                bool allConditionsPassed = true;
                if (statusEffectConfig.Conditions != null)
                {
                    foreach (var condition in statusEffectConfig.Conditions)
                    {
                        bool isOffsetChainValid = true;
                        List<long> offsets = new List<long>();
                        foreach (var offsetString in condition.Offsets)
                        {
                            if (TryParseHex(offsetString, out var offset))
                            {
                                offsets.Add(offset);
                            }
                            else
                            {
                                isOffsetChainValid = false;
                                break;
                            }
                        }

                        if (!isOffsetChainValid)
                        {
                            allConditionsPassed = false;
                            break;
                        }

                        var conditionAddress = MemoryHelper.ReadMultiLevelPointer(false, process, sourceAddress + (ulong)offsets.First(), offsets.Skip(1).ToArray());

                        bool isPassed = false;
                        if (condition.ByteValue.HasValue)
                        {
                            var conditionValue = MemoryHelper.Read<byte>(process, conditionAddress);
                            isPassed = conditionValue == condition.ByteValue;
                        }
                        else if (condition.IntValue.HasValue)
                        {
                            var conditionValue = MemoryHelper.Read<int>(process, conditionAddress);
                            isPassed = conditionValue == condition.IntValue;
                        }
                        else if (condition.StringRegexValue != null)
                        {
                            var conditionValue = MemoryHelper.ReadString(process, conditionAddress, 64);
                            isPassed = new Regex(condition.StringRegexValue).IsMatch(conditionValue);
                        }

                        if (!isPassed)
                        {
                            allConditionsPassed = false;
                            break;
                        }
                    }
                }

                float? timer = null;
                if (allConditionsPassed && statusEffectConfig.TimerOffset != null)
                {
                    if (TryParseHex(statusEffectConfig.TimerOffset, out var timerOffset))
                    {
                        timer = MemoryHelper.Read<float>(process, (ulong)((long)sourceAddress + timerOffset));
                    }

                    if (timer <= 0)
                    {
                        timer = 0;
                        allConditionsPassed = false;
                    }
                }

                OverlayViewModel.Instance.PlayerWidget.Context.UpdateAndGetPlayerStatusEffect(index, timer, allConditionsPassed);
            }
        }

        public static void UpdateTeamWidget(Process process, ulong playerDamageCollectionAddress, ulong playerNameCollectionAddress)
        {
            List<Player> updatedPlayers = new List<Player>();
            for (int playerIndex = 0; playerIndex < DataOffsets.PlayerDamageCollection.MaxPlayerCount; ++playerIndex)
            {
                var player = UpdateAndGetTeamPlayer(process, playerIndex, playerDamageCollectionAddress, playerNameCollectionAddress);
                if (player != null)
                {
                    updatedPlayers.Add(player);
                }
            }

            if (updatedPlayers.Any())
            {
                OverlayViewModel.Instance.TeamWidget.Context.UpdateFractions();
            }
            else if (OverlayViewModel.Instance.TeamWidget.Context.Players.Any())
            {
                OverlayViewModel.Instance.TeamWidget.Context.Players.Clear();
            }
        }

        private static Player UpdateAndGetTeamPlayer(Process process, int playerIndex, ulong playerDamageCollectionAddress, ulong playerNameCollectionAddress)
        {
            Player player = null;

            var playerNameOffset = (ulong)DataOffsets.PlayerNameCollection.PlayerNameLength * (ulong)playerIndex;
            string name = MemoryHelper.ReadString(process, playerNameCollectionAddress + DataOffsets.PlayerNameCollection.FirstPlayerName + playerNameOffset, (uint)DataOffsets.PlayerNameCollection.PlayerNameLength);
            ulong firstPlayerPtr = playerDamageCollectionAddress + DataOffsets.PlayerDamageCollection.FirstPlayerPtr; // check those lines
            ulong currentPlayerPtr = firstPlayerPtr + ((ulong)playerIndex * DataOffsets.PlayerDamageCollection.NextPlayerPtr);
            ulong currentPlayerAddress = MemoryHelper.Read<ulong>(process, currentPlayerPtr);
            int damage = MemoryHelper.Read<int>(process, currentPlayerAddress + DataOffsets.PlayerDamage.Damage);

            if (!String.IsNullOrEmpty(name) || damage > 0)
            {
                player = OverlayViewModel.Instance.TeamWidget.Context.UpdateAndGetPlayer(playerIndex, name, damage);
            }

            return player;
        }

        public static void UpdateMonsterWidget(Process process, ulong monsterBaseList)
        {
            if (monsterBaseList < 0xffffff)
            {
                OverlayViewModel.Instance.MonsterWidget.Context.Monsters.Clear();
                return;
            }

            List<ulong> monsterAddresses = new List<ulong>();

            ulong firstMonster = MemoryHelper.Read<ulong>(process, monsterBaseList + DataOffsets.Monster.PreviousMonsterOffset);

            if (firstMonster == 0x0)
            {
                firstMonster = monsterBaseList;// + DataOffsets.Monster.MonsterStartOfStructOffset;
            }

            firstMonster += DataOffsets.Monster.MonsterStartOfStructOffset;

            ulong currentMonsterAddress = firstMonster;
            while (currentMonsterAddress != 0)
            {
                monsterAddresses.Insert(0, currentMonsterAddress);
                currentMonsterAddress = MemoryHelper.Read<ulong>(process, currentMonsterAddress + DataOffsets.Monster.NextMonsterOffset);
            }

            List<Monster> updatedMonsters = new List<Monster>();
            foreach (var monsterAddress in monsterAddresses)
            {
                var monster = UpdateAndGetMonster(process, monsterAddress);
                if (monster != null)
                {
                    updatedMonsters.Add(monster);
                }
            }

            // Clean out monsters that aren't in the linked list anymore
            var obsoleteMonsters = OverlayViewModel.Instance.MonsterWidget.Context.Monsters.Except(updatedMonsters);
            foreach (var obsoleteMonster in obsoleteMonsters.Reverse())
            {
                OverlayViewModel.Instance.MonsterWidget.Context.Monsters.Remove(obsoleteMonster);
            }
        }

        private static Monster UpdateAndGetMonster(Process process, ulong monsterAddress)
        {
            Monster monster = null;

            ulong tmp = monsterAddress + DataOffsets.Monster.MonsterStartOfStructOffset + DataOffsets.Monster.MonsterHealthComponentOffset;
            ulong health_component = MemoryHelper.Read<ulong>(process, tmp);
            
            string id = MemoryHelper.ReadString(process, tmp + DataOffsets.MonsterModel.IdOffset, (uint)DataOffsets.MonsterModel.IdLength);
            float maxHealth = MemoryHelper.Read<float>(process, health_component + DataOffsets.MonsterHealthComponent.MaxHealth);

            if (String.IsNullOrEmpty(id))
            {
                return monster;
            }

            id = id.Split('\\').Last();
            if (!Monster.IsIncluded(id))
            {
                return monster;
            }

            if (maxHealth <= 0)
            {
                return monster;
            }

            float currentHealth = MemoryHelper.Read<float>(process, health_component + DataOffsets.MonsterHealthComponent.CurrentHealth);
            float sizeScale = MemoryHelper.Read<float>(process, monsterAddress + DataOffsets.Monster.MonsterStartOfStructOffset + DataOffsets.Monster.SizeScale);

            monster = OverlayViewModel.Instance.MonsterWidget.Context.UpdateAndGetMonster(monsterAddress, id, maxHealth, currentHealth, sizeScale);

            
            if (SmartHunter.Game.Helpers.ConfigHelper.MonsterData.Values.Monsters.ContainsKey(id) && SmartHunter.Game.Helpers.ConfigHelper.MonsterData.Values.Monsters[id].Parts.Count() > 0)
            {
                /*
                 * If you reading this then problably you can try to help me.
                 * This is a first step into monster status effects reading, so far i know:
                 * 1)Status effects are structs with length of 0x240
                 * 2)Status duration is at offset 0x1B4
                 * 3)Max duration ?
                 * 4)Each struct is double linked -> 0x8 -> base pointer; 0x10 ->previous pointer; 0x18 is next pointer;
                 * 
                 * 
                */
                /*
                var p = MemoryHelper.ReadMultiLevelPointer(false, process, monsterAddress + 0xF0, 0x198, 0x0);
                var p1 = MemoryHelper.ReadMultiLevelPointer(false, process, monsterAddress + 0x10, 0x100, 0x128, 0x0);
                var p2 = MemoryHelper.ReadMultiLevelPointer(false, process, monsterAddress + 0x10, 0xF8, 0xF8, 0x0);
                

                var t = MemoryHelper.Read<ulong>(process, monsterAddress + DataOffsets.Monster.MonsterStartOfStructOffset + 0x78);
                var t1 = MemoryHelper.Read<ulong>(process, t + 0x57A8);

                t1 = MemoryHelper.ReadMultiLevelPointer(false, process, t1 + 0x18, 0x18, 0x0); //With this i can get the base pointer for the status double linked list, my main problem is to identify to which monster this is attached to as every monster points to the same address (for now)

                var wut = MemoryHelper.ReadMultiLevelPointer(false, process, monsterAddress + DataOffsets.Monster.MonsterStartOfStructOffset + 0x78, 0x57A8, 0x18, 0x18, 0x0);

                //Ignore from this line as this was only for testing

                int i = 0;

                ulong t2 = t1 + 0x40;
                while (t2 != 0)
                {
                    if (t2 == 0x1afaa15d0)
                    {
                        break;
                    }
                    t2 = MemoryHelper.Read<ulong>(process, t2 + DataOffsets.Monster.NextMonsterOffset);
                    i++;
                }

                */

                // TODO: I think here we can check if the current player is the host of the party, as if's not there's no point on updating monster parts (cause only the host of the party will see those parts)
                UpdateMonsterParts(process, monster);
                UpdateMonsterRemovableParts(process, monster);
                UpdateMonsterStatusEffects(process, monster);
            }

            return monster;
        }

        private static void UpdateMonsterParts(Process process, Monster monster)
        {
            var parts = monster.Parts.Where(part => !part.IsRemovable);
            if (parts.Any())
            {
                foreach (var part in parts)
                {
                    UpdateMonsterPart(process, monster, part.Address);
                }
            }
            else
            {
                ulong firstPartAddress = monster.Address + DataOffsets.Monster.PartCollection + DataOffsets.MonsterPartCollection.FirstPart;

                for (int index = 0; index < DataOffsets.MonsterPartCollection.MaxItemCount; ++index)
                {
                    ulong currentPartOffset = DataOffsets.MonsterPart.NextPart * (ulong)index;
                    ulong currentPartAddress = firstPartAddress + currentPartOffset;

                    float maxHealth = MemoryHelper.Read<float>(process, currentPartAddress + DataOffsets.MonsterPart.MaxHealth);

                    if (maxHealth > 0)
                    {
                        UpdateMonsterPart(process, monster, currentPartAddress);
                    }
                }
            }
        }

        private static void UpdateMonsterPart(Process process, Monster monster, ulong partAddress)
        {
            float maxHealth = MemoryHelper.Read<float>(process, partAddress + DataOffsets.MonsterPart.MaxHealth);
            float currentHealth = MemoryHelper.Read<float>(process, partAddress + DataOffsets.MonsterPart.CurrentHealth);
            int timesBrokenCount = MemoryHelper.Read<int>(process, partAddress + DataOffsets.MonsterPart.TimesBrokenCount);

            monster.UpdateAndGetPart(partAddress, false, maxHealth, currentHealth, timesBrokenCount);
        }

        private static void UpdateMonsterRemovableParts(Process process, Monster monster)
        {
            var removableParts = monster.Parts.Where(part => part.IsRemovable);
            if (removableParts.Any())
            {
                foreach (var removablePart in removableParts)
                {
                    UpdateMonsterRemovablePart(process, monster, removablePart.Address);
                }
            }
            else
            {
                ulong removablePartAddress = monster.Address + DataOffsets.Monster.RemovablePartCollection + DataOffsets.MonsterRemovablePartCollection.FirstRemovablePart;
                for (int index = 0; index < DataOffsets.MonsterRemovablePartCollection.MaxItemCount; ++index)
                {
                    // Every 16 elements there seems to be a new removable part collection. When we reach this point,
                    // we advance past the first 64 bit field to get to the start of the next part again
                    ulong staticPtr = MemoryHelper.Read<ulong>(process, removablePartAddress);
                    if (staticPtr <= 10)
                    {
                        removablePartAddress += 8;
                    }
                    
                    // This is rough/hacky but it removes seemingly valid parts that aren't actually "removable".
                    // TODO: Figure out why Paolumu, Barroth, Radobaan have these mysterious removable parts
                    bool isValid1 = true;
                    bool isValid2 = true;
                    bool isValid3 = true;

                    int validity1 = MemoryHelper.Read<int>(process, removablePartAddress + DataOffsets.MonsterRemovablePart.Validity1);
                    isValid1 = validity1 == 1;
                    if (!ConfigHelper.Main.Values.Debug.ShowWeirdRemovableParts)
                    {                                           
                        int validity2 = MemoryHelper.Read<int>(process, removablePartAddress + DataOffsets.MonsterRemovablePart.Validity2);
                        int validity3 = MemoryHelper.Read<int>(process, removablePartAddress + DataOffsets.MonsterRemovablePart.Validity3);

                        isValid2 = validity3 == 0 || validity3 == 1;

                        isValid3 = true;
                        if (validity3 == 0 && validity2 != 1)
                        {
                            isValid3 = false;
                        }
                    }

                    if (isValid1 && isValid2 && isValid3)
                    {
                        float maxHealth = MemoryHelper.Read<float>(process, removablePartAddress + DataOffsets.MonsterRemovablePart.MaxHealth);
                        if (maxHealth > 0)
                        {
                            UpdateMonsterRemovablePart(process, monster, removablePartAddress);
                        }
                        else
                        {
                            break;
                        }
                    }

                    removablePartAddress += DataOffsets.MonsterRemovablePart.NextRemovablePart;
                }
            }
        }

        private static void UpdateMonsterRemovablePart(Process process, Monster monster, ulong removablePartAddress)
        {
            float maxHealth = MemoryHelper.Read<float>(process, removablePartAddress + DataOffsets.MonsterRemovablePart.MaxHealth);
            float currentHealth = MemoryHelper.Read<float>(process, removablePartAddress + DataOffsets.MonsterRemovablePart.CurrentHealth);
            int timesBrokenCount = MemoryHelper.Read<int>(process, removablePartAddress + DataOffsets.MonsterRemovablePart.TimesBrokenCount);

            monster.UpdateAndGetPart(removablePartAddress, true, maxHealth, currentHealth, timesBrokenCount);
        }

        private static void UpdateMonsterStatusEffects(Process process, Monster monster)
        {
            ulong statusEffectCollectionAddress = monster.Address + DataOffsets.Monster.StatusEffectCollection;

            for (int index = 0; index < ConfigHelper.MonsterData.Values.StatusEffects.Length; ++index)
            {
                var statusEffectConfig = ConfigHelper.MonsterData.Values.StatusEffects[index];

                var rootAddress = statusEffectCollectionAddress;

                if (statusEffectConfig.PointerOffset != null)
                {
                    if (TryParseHex(statusEffectConfig.PointerOffset, out var pointerOffset))
                    {
                        rootAddress = MemoryHelper.Read<ulong>(process, (ulong)((long)rootAddress + pointerOffset));//MemoryHelper.ReadMultiLevelPointer(false, process, (ulong)((long)rootAddress + pointerOffset), 0);
                    }
                }
                
                float maxBuildup = 0;
                float currentBuildup = 0;
                if (TryParseHex(statusEffectConfig.CurrentBuildupOffset, out var currentBuildupOffset)
                    && TryParseHex(statusEffectConfig.MaxBuildupOffset, out var maxBuildupOffset)
                    )
                {
                    maxBuildup = MemoryHelper.Read<float>(process, AddOffset(rootAddress, maxBuildupOffset));
                    if (maxBuildup > 0)
                    {
                        currentBuildup = MemoryHelper.Read<float>(process, AddOffset(rootAddress, currentBuildupOffset));
                    }
                }

                float maxDuration = 0;
                float currentDuration = 0;
                if (TryParseHex(statusEffectConfig.MaxDurationOffset, out var maxDurationOffset)
                   && TryParseHex(statusEffectConfig.CurrentDurationOffset, out var currentDurationOffset)
                   )
                {
                    maxDuration = MemoryHelper.Read<float>(process, AddOffset(rootAddress, maxDurationOffset));
                    if (maxDuration > 0)
                    {
                        currentDuration = MemoryHelper.Read<float>(process, AddOffset(rootAddress, currentDurationOffset));
                    }
                }

                int timesActivatedCount = 0;
                if (TryParseHex(statusEffectConfig.TimesActivatedOffset, out var timesActivatedOffset))
                {
                    timesActivatedCount = MemoryHelper.Read<int>(process, AddOffset(rootAddress, timesActivatedOffset));
                }

                if (maxBuildup > 0 || maxDuration > 0)
                {
                    monster.UpdateAndGetStatusEffect(index, maxBuildup > 0 ? maxBuildup : 1, !statusEffectConfig.InvertBuildup ? currentBuildup : maxBuildup - currentBuildup, maxDuration, !statusEffectConfig.InvertDuration ? currentDuration : maxDuration - currentDuration, timesActivatedCount);
                }
            }
        }
    }
}
