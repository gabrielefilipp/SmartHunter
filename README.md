# SmartHunter - Monster Hunter: World Overlay

A complete overlay for Monster Hunter: World on PC with Iceborne support. Originally distributed on [Nexus Mods](https://www.nexusmods.com/monsterhunterworld/mods/793). Features include:

- Monster widget - name, health, parts, status effect buildup, and crown.
- Team widget - name and damage meters.
- Player widget - buff, debuff, and equipment/mantle timers.
- Open source - freely learn from and contribute to the project.
- Skinnable - create and distribute your own rich styles and animations with XAML.
- Easy localization - create and distribute your own translations for our international friends.

## Requirements

- [.NET Framework runtime](https://dotnet.microsoft.com/download/dotnet-framework) (4.6.1 is required 4.8 is recommended).
- Monster Hunter: World running in borderless window or windowed mode.

## How to install

- Download the latest release from [here](https://github.com/sir-wilhelm/SmartHunter/releases) (Assets > SmartHunter.zip).
- Extract the contents of the zip.
- Right-click SmartHunter.exe > Properties > check Unblock > click OK.

## How to use

- Launch `SmartHunter.exe`.
- Hold `LeftAlt` to view widget locations.
- Click and drag widgets to move them.
- Use the mouse wheel scroll over widgets to rescale them.
- Other modifiers:
    - Press and hold `F1` to hide all widgets.
    - Press `RightCtrl` to toggle widget visibility.

### How to update

- SmartHunter automatically checks the latest release, and if a new version is released it will auto download, extract, and clean up the old files.
- To disable this feature set `AutomaticallyCheckAndDownloadUpdates` to `false` in `Config.json`.
- You can always grab the latest version from the [releases](https://github.com/sir-wilhelm/SmartHunter/releases) page.

### How to use custom data

- To better support auto updates, the .json data files are recreated by default. 
- To change/use custom data files set `UseCustomData` to `true` in `Config.json`.
- Note: Memory.json is not 

### How to create and use new localizations

- Create a copy of `en-US.json` and rename it for the locale you are translating to.
- Translate the strings in the second part of each key value pair. Do not change the keys.
- Ensure the new file is in the SmartHunter folder.
- Open `Config.json` and point `LocalizationFileName` to the new file.

### How to create and use new skins

- Create a copy of `Default.xaml` and rename it appropriately.
- Make changes to the new file.
- Ensure the new file is in the SmartHunter folder.
- Open `Config.json` and point `SkinFileName` to the new file.

# FAQ

Can I configure what is visible?
Yes - see `Config.json` documentation [here](/doc/Config.json.md).

Why don't monster parts and status effects update properly in multiplayer sessions?
This data only updates properly for the quest host. This is just the way the game works and it can't be worked around.

Where is the config file?
`Config.json` is generated when SmartHunter is first launched.
