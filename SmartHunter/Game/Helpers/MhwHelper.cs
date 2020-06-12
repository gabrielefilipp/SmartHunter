using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using SmartHunter.Core.Helpers;
using SmartHunter.Game.Config;
using SmartHunter.Game.Data;
using SmartHunter.Game.Data.ViewModels;

namespace SmartHunter.Game.Helpers
{
    public static class MhwHelper
    {
        public static bool TryParseHex(string hexString, out long hexNumber)
        {
            if (hexString.StartsWith("-"))
            {
                bool res = long.TryParse(hexString.Substring(1), NumberStyles.HexNumber, CultureInfo.InvariantCulture, out hexNumber);
                hexNumber = (-1) * hexNumber;
                return res;
            }
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
                public static readonly ulong SizeScale = 0x188;
                public static readonly ulong ScaleModifier = 0x7730;
                public static readonly ulong PartCollection = 0x14528;
                public static readonly ulong RemovablePartCollection = PartCollection + 0x22A0 - 0xF0 - 0xF0 - 0xF0 - 0x38;
                public static readonly ulong StatusEffectCollection = 0x19900;
                public static readonly ulong MonsterStaminaOffset = 0x1C0F0;
                public static readonly ulong MonsterRageOffset = 0x1BE54;
            }

            public static class MonsterModel
            {
                public static readonly uint IdLength = 32;
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
                public static readonly ulong FirstPart = 0x1C;
            }

            public static class MonsterPart
            {
                public static readonly ulong MaxHealth = 0x00;
                public static readonly ulong CurrentHealth = 0x04;
                public static readonly ulong TimesBrokenCount = 0x0C;
                public static readonly ulong NextPart = 0x1F8;
            }

            public static class MonsterRemovablePartCollection
            {
                public static readonly int MaxItemCount = 32;
                public static readonly ulong FirstRemovablePart = 0x78;
            }

            public static class MonsterRemovablePart
            {
                public static readonly ulong MaxHealth = 0x0C;
                public static readonly ulong CurrentHealth = 0x10;
                public static readonly ulong TimesBrokenCount = 0x18;
                public static readonly ulong NextRemovablePart = 0x78;
            }

            public static class MonsterStatusEffectCollection
            {
                public static int MaxItemCount = 20;
                public static ulong NextStatusEffectPtr = 0x08;
            }

            public static class MonsterStatusEffect
            {
                public static readonly ulong MaxDuration = 0x19C;
                public static readonly ulong CurrentBuildup = 0x1B8;
                public static readonly ulong MaxBuildup = 0x1C8;
                public static readonly ulong CurrentDuration = 0x1F8;
                public static readonly ulong TimesActivatedCount = 0x200;
            }

            public static class PlayerNameCollection
            {
                public static readonly int IDLength = 12 + 1; // +1 for null terminator
                public static readonly int PlayerNameLength = 32 + 1; // +1 for null terminator
                public static readonly ulong FirstPlayerName = 0x532ED;
                public static readonly ulong SessionID = FirstPlayerName + 0xF43;
                public static readonly ulong SessionHostPlayerName = SessionID + 0x3F;
                public static readonly ulong LobbyID = FirstPlayerName + 0x463;
                public static readonly ulong LobbyHostPlayerName = LobbyID + 0x29;
                public static readonly ulong NextLobbyHostName = 0x2F; // Is dis even right?
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

        public static void UpdateCurrentGame(Process process, ulong playerNameCollectionAddress, ulong currentPlayerNameAddress, ulong currentWeaponAddress, ulong lobbyStatusAddress)
        {
            string currentSessionID = MemoryHelper.ReadString(process, playerNameCollectionAddress + DataOffsets.PlayerNameCollection.SessionID, (uint)DataOffsets.PlayerNameCollection.IDLength);
            string currentSessionPlayerName = "";
            if (currentSessionID.Length > 0)
            {
                currentSessionPlayerName = MemoryHelper.ReadString(process, playerNameCollectionAddress + DataOffsets.PlayerNameCollection.SessionHostPlayerName, (uint)DataOffsets.PlayerNameCollection.PlayerNameLength);
            }

            string currentPlayerName = MemoryHelper.ReadString(process, currentPlayerNameAddress, (uint)DataOffsets.PlayerNameCollection.PlayerNameLength);

            string currentLobbyID = "";
            string currentLobbyPlayerName = "";
            bool isPlayerInMission = MemoryHelper.Read<uint>(process, lobbyStatusAddress + 0x54) != 0x0;
            bool isPlayerInExpedition = MemoryHelper.Read<uint>(process, lobbyStatusAddress + 0x38) != 0x1;
            if (isPlayerInMission || isPlayerInExpedition)
            {
                if (currentSessionID.Length > 0)
                {
                    currentLobbyID = MemoryHelper.ReadString(process, playerNameCollectionAddress + DataOffsets.PlayerNameCollection.LobbyID, (uint)DataOffsets.PlayerNameCollection.IDLength);
                    if (currentLobbyID.Length > 0)
                    {
                        for (int index = 0; index < 4; index++)
                        {
                            ulong PlayerNameOffset = DataOffsets.PlayerNameCollection.NextLobbyHostName * (ulong)index;
                            currentLobbyPlayerName = MemoryHelper.ReadString(process, playerNameCollectionAddress + DataOffsets.PlayerNameCollection.LobbyHostPlayerName + PlayerNameOffset, (uint)DataOffsets.PlayerNameCollection.PlayerNameLength);
                            if (currentLobbyPlayerName.Length > 0)
                            {
                                break;
                            }
                        }
                    }
                }
                else
                {
                    currentLobbyID = "Not Online";
                    currentLobbyPlayerName = currentPlayerName;
                }
            }

            string currentEquippedWeaponString = MemoryHelper.ReadString(process, currentWeaponAddress, 0x4F);
            OverlayViewModel.Instance.DebugWidget.Context.UpdateCurrentGame(currentPlayerName, currentEquippedWeaponString, currentSessionID, currentSessionPlayerName, currentLobbyID, currentLobbyPlayerName);
        }

        public static void UpdatePlayerWidget(Process process, ulong baseAddress, ulong equipmentAddress, ulong weaponAddress)
        {
            for (int index = 0; index < ConfigHelper.PlayerData.Values.StatusEffects.Length; ++index)
            {
                var statusEffectConfig = ConfigHelper.PlayerData.Values.StatusEffects[index];

                var sourceAddress = statusEffectConfig.Source switch
                {
                    MemorySource.Base => baseAddress,
                    MemorySource.Equipment => equipmentAddress,
                    MemorySource.Weapon => weaponAddress,
                    _ => baseAddress,
                };

                var allConditionsPassed = true;
                if (statusEffectConfig.Conditions != null)
                {
                    foreach (var condition in statusEffectConfig.Conditions)
                    {
                        var isOffsetChainValid = true;
                        var offsets = new List<long>();
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

                        var isPassed = false;
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

                if (statusEffectConfig.Source == MemorySource.Weapon)
                {
                    if (!OverlayViewModel.Instance.DebugWidget.Context.CurrentGame.IsValid)
                    {
                        continue;
                    }
                    if (OverlayViewModel.Instance.DebugWidget.Context.CurrentGame.CurrentEquippedWeaponType() != statusEffectConfig.WeaponType)
                    {
                        allConditionsPassed = false;
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
            var players = new List<Player>();

            for (var playerIndex = 0; playerIndex < DataOffsets.PlayerDamageCollection.MaxPlayerCount; ++playerIndex)
            {
                var player = UpdateAndGetTeamPlayer(process, playerIndex, playerDamageCollectionAddress, playerNameCollectionAddress);
                if (player != null)
                {
                    players.Add(player);
                }
            }

            if (players.Any())
            {
                OverlayViewModel.Instance.TeamWidget.Context.UpdateFractions();
            }
            else if (OverlayViewModel.Instance.TeamWidget.Context.Players.Any())
            {
                OverlayViewModel.Instance.TeamWidget.Context.ClearPlayers();
            }
        }

        private static Player UpdateAndGetTeamPlayer(Process process, int playerIndex, ulong playerDamageCollectionAddress, ulong playerNameCollectionAddress)
        {
            var playerNameOffset = (ulong)DataOffsets.PlayerNameCollection.PlayerNameLength * (ulong)playerIndex;
            var name = MemoryHelper.ReadString(process, playerNameCollectionAddress + DataOffsets.PlayerNameCollection.FirstPlayerName + playerNameOffset, (uint)DataOffsets.PlayerNameCollection.PlayerNameLength);
            var firstPlayerPtr = playerDamageCollectionAddress + DataOffsets.PlayerDamageCollection.FirstPlayerPtr;
            var currentPlayerPtr = firstPlayerPtr + ((ulong)playerIndex * DataOffsets.PlayerDamageCollection.NextPlayerPtr);
            var currentPlayerAddress = MemoryHelper.Read<ulong>(process, currentPlayerPtr);
            var damage = MemoryHelper.Read<int>(process, currentPlayerAddress + DataOffsets.PlayerDamage.Damage);

            return !string.IsNullOrEmpty(name) && damage > 0
                ? OverlayViewModel.Instance.TeamWidget.Context.UpdateAndGetPlayer(playerIndex, name, damage)
                : null;
        }

        public static void UpdateMonsterWidget(Process process, ulong monsterBaseList, ulong mapBaseAddress)
        {
            if (mapBaseAddress != 0x0)
            {
                // update pointer address
                bool isMonsterSelected = MemoryHelper.Read<ulong>(process, mapBaseAddress + 0x128) != 0x0;
                if (isMonsterSelected)
                {
                    ulong selectedMonsterAddress = MemoryHelper.Read<ulong>(process, mapBaseAddress + 0x148);
                    var selectedMonster = UpdateAndGetMonster(process, selectedMonsterAddress);
                    if (selectedMonster != null)
                    {
                        var toRemoveMonsters = OverlayViewModel.Instance.MonsterWidget.Context.Monsters.Where(m => !m.Id.Equals(selectedMonster.Id));
                        foreach (var obsoleteMonster in toRemoveMonsters.Reverse())
                        {
                            OverlayViewModel.Instance.MonsterWidget.Context.Monsters.Remove(obsoleteMonster);
                        }
                        return;
                    }
                }
            }

            if (monsterBaseList < 0xffffff)
            {
                OverlayViewModel.Instance.MonsterWidget.Context.Monsters.Clear();
                return;
            }

            var monsterAddresses = new List<ulong>()
            {
                MemoryHelper.Read<ulong>(process, MemoryHelper.Read<ulong>(process, monsterBaseList - 0x30) + 0x10) + 0x40,
                MemoryHelper.Read<ulong>(process, monsterBaseList - 0x30) + 0x40,
                monsterBaseList,
            };

            var updatedMonsters = new List<Monster>();
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

            var monster_health_address = monsterAddress + DataOffsets.Monster.MonsterHealthComponentOffset;
            var health_component = MemoryHelper.Read<ulong>(process, monster_health_address);
            var nameptr = MemoryHelper.Read<ulong>(process, monsterAddress + 0x2A0);
            var id = MemoryHelper.ReadString(process, nameptr + 0x0C, DataOffsets.MonsterModel.IdLength);
            var maxHealth = MemoryHelper.Read<float>(process, health_component + DataOffsets.MonsterHealthComponent.MaxHealth);

            if (string.IsNullOrEmpty(id))
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
            float sizeScale = MemoryHelper.Read<float>(process, monsterAddress + DataOffsets.Monster.SizeScale);
            float scaleModifier = MemoryHelper.Read<float>(process, monsterAddress + DataOffsets.Monster.ScaleModifier);
            if (scaleModifier <= 0 || scaleModifier >= 2)
            {
                scaleModifier = 1;
            }

            monster = OverlayViewModel.Instance.MonsterWidget.Context.UpdateAndGetMonster(monsterAddress, id, maxHealth, currentHealth, sizeScale, scaleModifier);

            if (ConfigHelper.MonsterData.Values.Monsters.ContainsKey(id) && ConfigHelper.MonsterData.Values.Monsters[id].Parts.Count() > 0)
            {
                if (!OverlayViewModel.Instance.DebugWidget.Context.CurrentGame.IsValid || OverlayViewModel.Instance.DebugWidget.Context.CurrentGame.IsCurrentPlayerLobbyHost() || !OverlayViewModel.Instance.DebugWidget.Context.CurrentGame.IsPlayerOnline())
                {
                    UpdateMonsterParts(process, monster);
                    if (ConfigHelper.MonsterData.Values.Monsters[id].Parts.Where(p => p.IsRemovable).Count() > 0) // In case you are testing add "|| true"
                    {
                        UpdateMonsterRemovableParts(process, monster);
                    }
                }

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

                    float maxHealth = MemoryHelper.Read<float>(process, currentPartAddress);

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
                ulong removablePartAddress = monster.Address + DataOffsets.Monster.RemovablePartCollection;
                for (int index = 0; index < DataOffsets.MonsterRemovablePartCollection.MaxItemCount; ++index)
                {
                    // Every 16 elements there seems to be a new removable part collection. When we reach this point,
                    // we advance past the first 64 bit field to get to the start of the next part again
                    ulong staticPtr = MemoryHelper.Read<ulong>(process, removablePartAddress);
                    if (staticPtr <= 10)
                    {
                        removablePartAddress += 8;
                    }

                    uint maxRemovableParts = (uint)ConfigHelper.MonsterData.Values.Monsters[monster.Id].Parts.Where(p => p.IsRemovable).Count();
                    bool isLast = MemoryHelper.Read<uint>(process, removablePartAddress + 0x94) == 0x1;
                    //bool isValid = MemoryHelper.Read<byte>(process, removablePartAddress + 0x15) == 0;
                    bool isValid = MemoryHelper.Read<uint>(process, removablePartAddress + 0x6C) < maxRemovableParts;

                    if (isValid)
                    {
                        float maxHealth = MemoryHelper.Read<float>(process, removablePartAddress + DataOffsets.MonsterRemovablePart.MaxHealth);
                        if (maxHealth > 0)
                        {
                            UpdateMonsterRemovablePart(process, monster, removablePartAddress);
                            if (isLast || monster.Parts.Where(p => p.IsRemovable).Count() == maxRemovableParts)
                            {
                                break;
                            }
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
            int maxIndex = ConfigHelper.MonsterData.Values.StatusEffects.Where(s => s.GroupId.Equals("StatusEffect")).Count() - 1;
            var statuses = monster.StatusEffects;
            if (statuses != null && statuses.Where(s => s.GroupId.Equals("StatusEffect")).Any())
            {
                for (int i = 0; i < statuses.Count(); i++)
                {
                    MonsterStatusEffect status = statuses[i];
                    if (status == null)
                    {
                        continue;
                    }
                    float currentBuildup = 0;
                    float maxBuildup = MemoryHelper.Read<float>(process, status.Address + DataOffsets.MonsterStatusEffect.MaxBuildup);
                    if (maxBuildup > 0)
                    {
                        currentBuildup = MemoryHelper.Read<float>(process, status.Address + DataOffsets.MonsterStatusEffect.CurrentBuildup);
                    }
                    float currentDuration = 0;
                    float maxDuration = MemoryHelper.Read<float>(process, status.Address + DataOffsets.MonsterStatusEffect.MaxDuration);
                    if (maxDuration > 0)
                    {
                        currentDuration = MemoryHelper.Read<float>(process, status.Address + DataOffsets.MonsterStatusEffect.CurrentDuration);
                    }
                    int timesActivatedCount = MemoryHelper.Read<int>(process, status.Address + DataOffsets.MonsterStatusEffect.TimesActivatedCount);

                    if (maxBuildup > 0 || maxDuration > 0)
                    {
                        uint index = MemoryHelper.Read<uint>(process, status.Address + 0x198);
                        if (index <= maxIndex)
                        {
                            var statusEffectConfig = ConfigHelper.MonsterData.Values.StatusEffects[index];
                            monster.UpdateAndGetStatusEffect(status.Address, (int)index, maxBuildup > 0 ? maxBuildup : 1, !statusEffectConfig.InvertBuildup ? currentBuildup : maxBuildup - currentBuildup, maxDuration, !statusEffectConfig.InvertDuration ? currentDuration : maxDuration - currentDuration, timesActivatedCount);
                        }
                    }
                }
            }
            else
            {
                ulong baseStatus = MemoryHelper.Read<ulong>(process, monster.Address + 0x78);
                baseStatus = MemoryHelper.Read<ulong>(process, baseStatus + 0x57A8);
                ulong nani = baseStatus;
                while (nani != 0)
                {
                    nani = MemoryHelper.Read<ulong>(process, nani + 0x10);
                    if (nani != 0)
                    {
                        baseStatus = nani;
                    }
                }
                ulong currentStatusPointer = baseStatus + 0x40;
                while (currentStatusPointer != 0x0)
                {
                    var currentMonsterInStatus = MemoryHelper.Read<ulong>(process, currentStatusPointer + 0x188);
                    if (currentMonsterInStatus == monster.Address && !monster.StatusEffects.Where(status => status.Address == currentStatusPointer).Any())
                    {
                        float currentBuildup = 0;
                        float maxBuildup = MemoryHelper.Read<float>(process, currentStatusPointer + DataOffsets.MonsterStatusEffect.MaxBuildup);
                        if (maxBuildup > 0)
                        {
                            currentBuildup = MemoryHelper.Read<float>(process, currentStatusPointer + DataOffsets.MonsterStatusEffect.CurrentBuildup);
                        }
                        float currentDuration = 0;
                        float maxDuration = MemoryHelper.Read<float>(process, currentStatusPointer + DataOffsets.MonsterStatusEffect.MaxDuration);
                        if (maxDuration > 0)
                        {
                            currentDuration = MemoryHelper.Read<float>(process, currentStatusPointer + DataOffsets.MonsterStatusEffect.CurrentDuration);
                        }
                        int timesActivatedCount = MemoryHelper.Read<int>(process, currentStatusPointer + DataOffsets.MonsterStatusEffect.TimesActivatedCount);

                        if (maxBuildup > 0 || maxDuration > 0)
                        {
                            uint index = MemoryHelper.Read<uint>(process, currentStatusPointer + 0x198);
                            if (index <= maxIndex && !((index == 14 || index == 15) && monster.isElder)) // skip traps for elders
                            {
                                var statusEffectConfig = ConfigHelper.MonsterData.Values.StatusEffects[index];
                                monster.UpdateAndGetStatusEffect(currentStatusPointer, (int)index, maxBuildup > 0 ? maxBuildup : 1, !statusEffectConfig.InvertBuildup ? currentBuildup : maxBuildup - currentBuildup, maxDuration, !statusEffectConfig.InvertDuration ? currentDuration : maxDuration - currentDuration, timesActivatedCount);
                            }
                        }
                    }
                    currentStatusPointer = MemoryHelper.Read<ulong>(process, currentStatusPointer + 0x18);
                }
            }

            // Stamina

            ulong staminaAddress = monster.Address + DataOffsets.Monster.MonsterStaminaOffset;
            float maxStaminaBuildUp = MemoryHelper.Read<float>(process, staminaAddress + 0x4);
            float currentStaminaBuildUp = 0;
            if (maxStaminaBuildUp > 0)
            {
                currentStaminaBuildUp = MemoryHelper.Read<float>(process, staminaAddress);
            }
            float maxFatigueDuration = MemoryHelper.Read<float>(process, staminaAddress + 0x0C);
            float currentFatigueDuration = 0;
            if (maxFatigueDuration > 0)
            {
                currentFatigueDuration = MemoryHelper.Read<float>(process, staminaAddress + 0x10);
            }
            int fatigueActivatedCount = MemoryHelper.Read<int>(process, staminaAddress + 0x14);
            MonsterStatusEffectConfig statusEffect = null;
            if (currentFatigueDuration > 0)
            {
                statusEffect = ConfigHelper.MonsterData.Values.StatusEffects.SingleOrDefault(s => s.GroupId.Equals("Fatigue"));
            }
            else
            {
                statusEffect = ConfigHelper.MonsterData.Values.StatusEffects.SingleOrDefault(s => s.GroupId.Equals("Stamina"));
            }

            if (maxStaminaBuildUp > 0 || currentFatigueDuration > 0)
            {
                monster.UpdateAndGetStatusEffect(staminaAddress, Array.IndexOf(ConfigHelper.MonsterData.Values.StatusEffects, statusEffect), maxStaminaBuildUp > 0 ? maxStaminaBuildUp : 1, !statusEffect.InvertBuildup ? currentStaminaBuildUp : maxStaminaBuildUp - currentStaminaBuildUp, maxFatigueDuration, !statusEffect.InvertDuration ? currentFatigueDuration : maxFatigueDuration - currentFatigueDuration, fatigueActivatedCount);
            }

            // Rage
            ulong rageAddress = monster.Address + DataOffsets.Monster.MonsterRageOffset;
            float maxRageBuildUp = MemoryHelper.Read<float>(process, rageAddress + 0x18);
            float currentRageBuildUp = 0;
            if (maxRageBuildUp > 0)
            {
                currentRageBuildUp = MemoryHelper.Read<float>(process, rageAddress - 0x0C);
            }
            float maxRageDuration = MemoryHelper.Read<float>(process, rageAddress + 0x04);
            float currentRageDuration = 0;
            if (maxRageDuration > 0)
            {
                currentRageDuration = MemoryHelper.Read<float>(process, rageAddress + 0x00);
            }
            int rageActivatedCount = MemoryHelper.Read<int>(process, rageAddress + 0x10);
            var rageStatusEffect = ConfigHelper.MonsterData.Values.StatusEffects.SingleOrDefault(s => s.GroupId.Equals("Rage"));//[33]; // 33 is rage
            if (maxRageBuildUp > 0 || maxRageDuration > 0)
            {
                monster.UpdateAndGetStatusEffect(rageAddress, Array.IndexOf(ConfigHelper.MonsterData.Values.StatusEffects, rageStatusEffect), maxRageBuildUp > 0 ? maxRageBuildUp : 1, !rageStatusEffect.InvertBuildup ? currentRageBuildUp : maxRageBuildUp - currentRageBuildUp, maxRageDuration, !rageStatusEffect.InvertDuration ? currentRageDuration : maxRageDuration - currentRageDuration, rageActivatedCount);
            }
        }
    }
}
