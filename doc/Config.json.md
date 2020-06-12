# `Config.json` documentation

SmartHunter can be customized from the `Config.json` file (generated after first launch).
Blelow are common settings that people might want to change.

## Global configurations
`"LocalizationFileName": "en-US.json",`
Changes the localization file used, defaults to `en-US.json`.

`"AutomaticallyCheckAndDownloadUpdates": true,`
defaults to `true`, set to `false` to disable.

`"UpdatesPerSecond": 20,`
The number time to check memory every second defaults to `20`, supports `1 to 60`.
Increase to improve performance.

### Overlay configurations
## TeamWidget
`"ShowNumbers": true,`
defaults to `true`, set to `false` to disable.

`"ShowPercents": true,`
defaults to `true`, set to `false` to disable.

`"IsVisible": true,`
defaults to `true`, set to `false` to disable.

## MonsterWidget
`"IncludePartGroupIdRegex": ".*",`
Available options: Part, Removable

`"IncludeStatusEffectGroupIdRegex": ".*",`
Available options: StatusEffect, Rage, Stamina, and Fatigue.

`"IsVisible": true,`
defaults to `true`, set to `false` to disable.

## PlayerWidget
`"IncludeStatusEffectGroupIdRegex": ".*",`
Availalbe options: Horn, Coral, Debuff, Buff, Equipment, and Weapon

`"IsVisible": true,`
defaults to `true`, set to `false` to disable.

# Example Config.json file
```json
{
  "LocalizationFileName": "en-US.json",
  "SkinFileName": "Default.xaml",
  "MonsterDataFileName": "MonsterData.json",
  "PlayerDataFileName": "PlayerData.json",
  "MemoryFileName": "Memory.json",
  "ShutdownWhenProcessExits": false,
  "UseCustomData": false,
  "AutomaticallyCheckAndDownloadUpdates": true,
  "Overlay": {
    "ScaleMin": 0.5,
    "ScaleMax": 2,
    "ScaleStep": 0.1,
    "HideWhenGameWindowIsInactive": false,
    "UpdatesPerSecond": 20,
    "TeamWidget": {
      "DontShowIfAlone": false,
      "ShowBars": true,
      "ShowNumbers": true,
      "ShowPercents": true,
      "IsVisible": true,
      "X": 2276,
      "Y": 1064,
      "Scale": 1
    },
    "MonsterWidget": {
      "IncludeMonsterIdRegex": "em[0-9]",
      "IncludePartGroupIdRegex": ".*",
      "IncludeStatusEffectGroupIdRegex": ".*",
      "ShowUnchangedMonsters": true,
      "HideMonstersAfterSeconds": 999,
      "ShowUnchangedParts": false,
      "HidePartsAfterSeconds": 12,
      "ShowUnchangedStatusEffects": false,
      "HideStatusEffectsAfterSeconds": 12,
      "ShowSize": false,
      "ShowCrown": true,
      "ShowBars": true,
      "ShowNumbers": true,
      "ShowPercents": true,
      "UseAnimations": false,
      "ShowOnlySelectedMonster": false,
      "IsVisible": true,
      "X": 945,
      "Y": 1,
      "Scale": 1
    },
    "PlayerWidget": {
      "IncludeStatusEffectGroupIdRegex": ".*",
      "IsVisible": true,
      "X": -14,
      "Y": 446,
      "Scale": 1
    },
    "DebugWidget": {
      "IsVisible": false,
      "X": 120,
      "Y": 320,
      "Scale": 1
    }
  },
  "Keybinds": {
    "ManipulateWidget": "LeftAlt",
    "HideWidgets": "F1"
  },
  "Debug": {
    "UseInternalSkin": false,
    "UseSampleData": false,
    "TraceUniquePointers": false,
    "ShowWeirdRemovableParts": false
  }
}
```
