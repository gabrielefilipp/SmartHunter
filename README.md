# SmartHunter - Monster Hunter: World Overlay

A complete overlay for Monster Hunter: World on PC. Distributed on [Nexus Mods](https://www.nexusmods.com/monsterhunterworld/mods/793). Features include:

- Monster widget - name, health, parts, status effect buildup, and crown.
- Team widget - name and damage meters.
- Player widget - buff, debuff, and equipment/mantle timers.
- Open source - freely learn from and contribute to the project.
- Skinnable - create and distribute your own rich styles and animations with XAML.
- Easy localization - create and distribute your own translations for our international friends.

## Requirements

- Windows.
- [The latest .NET Framework runtime](https://dotnet.microsoft.com/download/dotnet-framework-runtime).

## How to install

- Download `SmartHunter.exe` and `Newtonsoft.Json.dll` from here https://github.com/gabrielefilipp/SmartHunter/tree/master/SmartHunter/bin/x64/Debug.
- Place them in a new folder.
- IMPORTANT: If you are replacing the new `.exe` in the same folder of the old SmartHunter please REMEMBER to delete `Config.json`.
- You're ready for the hunt.

## How to use

- Launch `SmartHunter.exe`.
- Hold `LeftAlt` to view widget locations.
- Click and drag widgets to move them.
- Scroll over widgets to rescale them.

## How to update

- Following the commit https://github.com/gabrielefilipp/SmartHunter/commit/305b8a55eb4cd40c31a06a30ab862b4f803baa84 I've added an AutoUpdater module to this Application.
- To enable this feature just set the key 'AutomaticallyCheckAndDownloadUpdates' to 'true', if present, otherwise just add it, to the file `Config.json`.
- NOTE that this feature is already active if it's the first time you follow the "How to install" steps and download the mentioned files in a new directory.

## How to create and use new localizations

- Create a copy of `en-US.json` and rename it for the locale you are translating to.
- Translate the strings in the second part of each key value pair. Do not change the keys.
- Ensure the new file is in the SmartHunter folder.
- Open `Config.json` and point `LocalizationFileName` to the new file.

## How to create and use new skins

- Create a copy of `Default.xaml` and rename it appropriately.
- Make changes to the new file.
- Ensure the new file is in the SmartHunter folder.
- Open `Config.json` and point `SkinFileName` to the new file.

## Credits

- [HelloWorld](https://www.nexusmods.com/monsterhunterworld/users/58674841) for inspiring me with [their overlay](https://www.nexusmods.com/monsterhunterworld/mods/142).
- [Material1](https://www.nexusmods.com/monsterhunterworld/users/61777036) for their efforts in finding monster sizes.
- [hqvrrsc4](https://www.nexusmods.com/monsterhunterworld/users/7950104) for finding player data in [their overlay](https://www.nexusmods.com/monsterhunterworld/mods/88).
- [HelloWorld](https://www.nexusmods.com/monsterhunterworld/users/58674841), [amatess2002](https://www.nexusmods.com/users/59866791), [regretofabreath](https://www.nexusmods.com/monsterhunterworld/users/57977516), and [hawk333](https://www.nexusmods.com/monsterhunterworld/users/1939230) for their efforts in indexing monster parts.

## Disclaimer

Use with care and at your own risk. It is possible to get banned from games for using mods and overlays. There have been reports of people being banned from other games, such as PUBG, if overlays are accidentally left running in the background. To date, there have been no reports of players being banned from Monster Hunter: World for using mods and overlays, but that doesn't preclude it from happening in the future.
