using System.Linq;
using SmartHunter.Core;
using SmartHunter.Core.Helpers;
using SmartHunter.Game.Data.ViewModels;
using SmartHunter.Game.Helpers;

namespace SmartHunter.Game
{
    public class MhwMemoryUpdater : MemoryUpdater
    {
        BytePattern m_CurrentPlayerNamePattern = new BytePattern(ConfigHelper.Memory.Values.CurrentPlayerNamePattern);
        BytePattern m_CurrentWeaponPattern = new BytePattern(ConfigHelper.Memory.Values.CurrentWeaponPattern);
        BytePattern m_PlayerDamagePattern = new BytePattern(ConfigHelper.Memory.Values.PlayerDamagePattern);
        BytePattern m_PlayerNamePattern = new BytePattern(ConfigHelper.Memory.Values.PlayerNamePattern);
        BytePattern m_MonsterPattern = new BytePattern(ConfigHelper.Memory.Values.MonsterPattern);
        BytePattern m_PlayerBuffPattern = new BytePattern(ConfigHelper.Memory.Values.PlayerBuffPattern);
        BytePattern m_SelectedMonsterPattern = new BytePattern(ConfigHelper.Memory.Values.SelectedMonsterPattern);
        BytePattern m_LobbyStatusPattern = new BytePattern(ConfigHelper.Memory.Values.LobbyStatusPattern);

        protected override string ProcessName => ConfigHelper.Memory.Values.ProcessName;

        protected override int ThreadsPerScan => ConfigHelper.Memory.Values.ThreadsPerScan;

        protected override BytePattern[] Patterns => new BytePattern[]
            {
                m_CurrentPlayerNamePattern,
                m_CurrentWeaponPattern,
                m_PlayerDamagePattern,
                m_PlayerNamePattern,
                m_MonsterPattern,
                m_PlayerBuffPattern,
                m_SelectedMonsterPattern,
                m_LobbyStatusPattern
            };

        protected override int UpdatesPerSecond => ConfigHelper.Main.Values.Overlay.UpdatesPerSecond;

        protected override bool ShutdownWhenProcessExits => ConfigHelper.Main.Values.ShutdownWhenProcessExits;

        public MhwMemoryUpdater() => ConfigHelper.Main.Loaded += (s, e) => { TryUpdateTimerInterval(); };

        protected override void UpdateMemory()
        {
            UpdateVisibility();
            /*
            var range = new AddressRange(0x140000000, 0x226a3000);
            var range = new AddressRange(0x140000000, 0x169233000);
            //var pattern = new BytePattern(new Config.BytePatternConfig("48 8B 05 ?? ?? ?? ?? 41 8B", "140000000", "163B0A000", null));

            var pattern = new BytePattern(new Config.BytePatternConfig("null", "48 8B 0D ?? ?? ?? ??", null));
            var matches = MemoryHelper.FindPatternAddresses(Process, range, pattern, false);

            Log.WriteLine($"Found {matches.Count()} matches...");

            ulong[] lookingFor = new ulong[1] { 0x144DF2890 };

            var res = new System.Collections.Generic.List<ulong>();

            foreach (ulong address in matches)
            {
                ulong lear = MemoryHelper.LoadEffectiveAddressRelative(Process, address);
                foreach (ulong looking in lookingFor)
                {
                    if (looking == lear)
                    {
                        res.Add(address);
                        //Log.WriteLine($"Found match for 0x{looking} at 0x{address}");
                    }
                }
            }
            */
            var traceUniquePointers = ConfigHelper.Main.Values.Debug.TraceUniquePointers;

            if (m_PlayerNamePattern.MatchedAddresses.Any() && m_CurrentPlayerNamePattern.MatchedAddresses.Any() && m_CurrentWeaponPattern.MatchedAddresses.Any() && m_LobbyStatusPattern.MatchedAddresses.Any())
            {
                var playerNamesPtr = MemoryHelper.LoadEffectiveAddressRelative(Process, m_PlayerNamePattern.MatchedAddresses.First());
                var playerNamesAddress = MemoryHelper.Read<uint>(Process, playerNamesPtr);

                ulong currentPlayerNamePtr = MemoryHelper.LoadEffectiveAddressRelative(Process, m_CurrentPlayerNamePattern.MatchedAddresses.First());
                //ulong currentFelyneNameAddress = MemoryHelper.ReadMultiLevelPointer(traceUniquePointers, Process, currentPlayerNamePtr, 0xB40, 0x0, 0x890, 0x160, 0x8, 0x1E8, 0x7DC);

                var currentPlayerNameAddress = MemoryHelper.ReadMultiLevelPointer(traceUniquePointers, Process, currentPlayerNamePtr, 0xB20, 0x0, 0x530, 0xC0, 0x8, 0x78, 0x78);

                var currentWeaponPtr = MemoryHelper.LoadEffectiveAddressRelative(Process, m_CurrentWeaponPattern.MatchedAddresses.First());
                var currentWeaponAddress = MemoryHelper.ReadMultiLevelPointer(traceUniquePointers, Process, currentWeaponPtr, 0x80, 0x7500);

                var lobbyStatusPtr = MemoryHelper.LoadEffectiveAddressRelative(Process, m_LobbyStatusPattern.MatchedAddresses.First());
                var lobbyStatusAddress = MemoryHelper.Read<ulong>(Process, lobbyStatusPtr);

                MhwHelper.UpdateCurrentGame(Process, playerNamesAddress, currentPlayerNameAddress, currentWeaponAddress, lobbyStatusAddress);
            }

            if (!OverlayViewModel.Instance.DebugWidget.Context.CurrentGame.IsValid || OverlayViewModel.Instance.DebugWidget.Context.CurrentGame.IsPlayerInLobby())
            {
                if (ConfigHelper.Main.Values.Overlay.MonsterWidget.IsVisible && m_MonsterPattern.MatchedAddresses.Any())
                {
                    var monsterRootPtr = MemoryHelper.LoadEffectiveAddressRelative(Process, m_MonsterPattern.MatchedAddresses.First()); // - 0x36CE0(old) ... yeah i know this is basically a static pointer
                    var monsterBaseList = MemoryHelper.ReadMultiLevelPointer(traceUniquePointers, Process, monsterRootPtr, 0x698, 0x0, 0x138, 0x0);
                    ulong mapBaseAddress = 0x0;
                    if (ConfigHelper.Main.Values.Overlay.MonsterWidget.ShowOnlySelectedMonster && m_SelectedMonsterPattern.MatchedAddresses.Any())
                    {
                        var mapPtr = MemoryHelper.LoadEffectiveAddressRelative(Process, m_SelectedMonsterPattern.MatchedAddresses.First());
                        mapBaseAddress = MemoryHelper.Read<ulong>(Process, mapPtr);
                    }

                    MhwHelper.UpdateMonsterWidget(Process, monsterBaseList, mapBaseAddress);
                }
                else if (OverlayViewModel.Instance.MonsterWidget.Context.Monsters.Any())
                {
                    OverlayViewModel.Instance.MonsterWidget.Context.Monsters.Clear();
                }

                if (ConfigHelper.Main.Values.Overlay.TeamWidget.IsVisible && m_PlayerDamagePattern.MatchedAddresses.Any() && m_PlayerNamePattern.MatchedAddresses.Any() && (!OverlayViewModel.Instance.DebugWidget.Context.CurrentGame.IsValid || OverlayViewModel.Instance.DebugWidget.Context.CurrentGame.IsPlayerOnline()))
                {
                    var playerNamesPtr = MemoryHelper.LoadEffectiveAddressRelative(Process, m_PlayerNamePattern.MatchedAddresses.First());
                    var playerDamageRootPtr = MemoryHelper.LoadEffectiveAddressRelative(Process, m_PlayerDamagePattern.MatchedAddresses.First());
                    var playerDamageCollectionAddress = MemoryHelper.ReadMultiLevelPointer(traceUniquePointers, Process, playerDamageRootPtr, (long)MhwHelper.DataOffsets.PlayerDamageCollection.FirstPlayerPtr + (long)MhwHelper.DataOffsets.PlayerDamageCollection.MaxPlayerCount * sizeof(long) * (long)MhwHelper.DataOffsets.PlayerDamageCollection.NextPlayerPtr);
                    var playerNamesAddress = MemoryHelper.Read<uint>(Process, playerNamesPtr);

                    MhwHelper.UpdateTeamWidget(Process, playerDamageCollectionAddress, playerNamesAddress);
                }
                else if (OverlayViewModel.Instance.TeamWidget.Context.Players.Any())
                {
                    OverlayViewModel.Instance.TeamWidget.Context.ClearPlayers();
                }

                if (ConfigHelper.Main.Values.Overlay.PlayerWidget.IsVisible && m_PlayerBuffPattern.MatchedAddresses.Any())
                {
                    var playerBuffRootPtr = MemoryHelper.LoadEffectiveAddressRelative(Process, m_PlayerBuffPattern.MatchedAddresses.First());

                    var buffPtr = MemoryHelper.ReadMultiLevelPointer(traceUniquePointers, Process, playerBuffRootPtr, 0x8C8, 0x1C0, 0x0);

                    var lastBuffAddress = MemoryHelper.Read<ulong>(Process, buffPtr - 0x38) + 0x80;

                    var equipmentAddress = MemoryHelper.Read<ulong>(Process, lastBuffAddress + 0x14F8);
                    var weaponAddress = MemoryHelper.Read<ulong>(Process, lastBuffAddress + 0x76B0);
                    var buffAddress = MemoryHelper.Read<ulong>(Process, lastBuffAddress + 0x7D20);

                    MhwHelper.UpdatePlayerWidget(Process, buffAddress, equipmentAddress, weaponAddress);
                }
                else if (OverlayViewModel.Instance.PlayerWidget.Context.StatusEffects.Any())
                {
                    OverlayViewModel.Instance.PlayerWidget.Context.StatusEffects.Clear();
                }
            }
            else
            {
                OverlayViewModel.Instance.MonsterWidget.Context.Monsters.Clear();
                OverlayViewModel.Instance.TeamWidget.Context.ClearPlayers();
                OverlayViewModel.Instance.PlayerWidget.Context.StatusEffects.Clear();
            }
        }

        private void UpdateVisibility()
        {
            // Show or hide the overlay depending on whether the game process is active
            var foregroundWindowHandle = WindowsApi.GetForegroundWindow();
            if (ConfigHelper.Main.Values.Overlay.HideWhenGameWindowIsInactive && OverlayViewModel.Instance.IsVisible && foregroundWindowHandle != Process.MainWindowHandle)
            {
                OverlayViewModel.Instance.IsGameActive = false;
            }
            else if (!OverlayViewModel.Instance.IsVisible &&
                (!ConfigHelper.Main.Values.Overlay.HideWhenGameWindowIsInactive || foregroundWindowHandle == Process.MainWindowHandle))
            {
                OverlayViewModel.Instance.IsGameActive = true;
            }
        }
    }
}
