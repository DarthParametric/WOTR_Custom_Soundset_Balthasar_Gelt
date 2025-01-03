<p align="center"><img src="img/Gelt_Soundset_Header.png?raw=true" alt="Header image"/></p>

# About

A mod for Owlcat's Pathfinder: Wrath of the Righteous.

Adds a custom, standalone soundset for male PCs and mercenaries in Wrath of the Righteous, including custom casting lines that replace the vanilla chanting. Does not overwrite or replace any of the vanilla soundsets.

Also provides a couple of [custom portrait sets](https://github.com/DarthParametric/WOTR_Custom_Soundset_Balthasar_Gelt/releases/latest/download/Portraits.zip), if required.

# Install
1. Download and install [Unity Mod Manager](https://www.nexusmods.com/site/mods/21) and set it up for WOTR ("Pathfinder Second Adventure").
1. Download the latest version of the mod from [Github](https://github.com/DarthParametric/WOTR_Custom_Soundset_Balthasar_Gelt/releases/latest) or [Nexus Mods](https://www.nexusmods.com/pathfinderwrathoftherighteous/mods/713). Alternatively, it is now also available via [ModFinder](https://github.com/Pathfinder-WOTR-Modding-Community/ModFinder/releases/latest).
1. Download the latest version of ModMenu from [Github](https://github.com/CasDragon/ModMenu/releases/latest) or via [ModFinder](https://github.com/Pathfinder-WOTR-Modding-Community/ModFinder/releases/latest).
1. Install both mods manually, via UMM, or via ModFinder.
1. Run your game.
1. There is an optional setting in ModMenu that allows you to adjust the frequency of the movement barks, as these are quite infrequent by default:
   <p align="center"><img src="img/Gelt_Soundset_MM_Options.png?raw=true" alt="ModMenu bark config options screenshot" width="500" height="130"/></p>
1. The custom soundset will appear in the character creator Voice list for males after all the vanilla soundsets:
   <p align="center"><img src="img/Gelt_Soundset_Character_Creator_List.png?raw=true" alt="Character creator voice selection screenshot"/></p>

# Notes
- Just like vanilla chants, the custom casting chants won't play when a spell's casting animation is disabled. For example, a Quickened spell.
- While there is provision for both pre-cast and on-cast lines, I have left the pre-casts blank to avoid overlaps. This means a line will only play when a spell is finally cast.
- Certain lines may be overly loud due to the nature of the source audio. Please report anything obnoxious so it can be manually adjusted.
- The source audio lacks any sort of whispering or quiet lines, so I have simply lowered the volume on the stealth lines.
- Similarly, there's a lack of diversity or even anything appropriate at all for certain lines. If anyone skilled with AI voice generation is willing to take a crack at creating new custom lines, let me know.
- If you wish to use the optional included custom portraits, copy the folders into `%UserProfile%\AppData\LocalLow\Owlcat Games\Pathfinder Wrath of the Righteous\Portraits` (on Windows).

# Thanks & Acknowledgements
- Uses the `wrathsoundvoicemod` mod template from [OwlcatNuGetTemplates](https://github.com/xADDBx/OwlcatNuGetTemplates) as a basis.
- microsoftenator2022 - Provided lots of help with troubleshooting the original Wwise and project setup, leading to the creation of the dedicated `wrathsoundvoicemod` template (as well as extensive work on the original `wrathsoundmod` template) and provided corrections, fixes and suggestions for various coding issues, especially disabling the vanilla casting chants.
- Everyone in the `#mod-dev-technical` channel of the Owlcat Discord server for various modding-related discussions and suggestions, help troubleshooting issues, and answering general questions.
- Original audio taken from Creative Assembly's Total War Warhammer.
