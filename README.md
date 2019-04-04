# WANIC-Teacher-Metroid
Metroid clone in Unity.

## Unity Version
If you do any work, please make sure you are using Unity version 2018.3.0f2 (the same version that is installed on the WANIC student computers). This is the version we will be using for this project. Work done in older (or especially newer) versions is liable to cause serious issues.

## Version Control Guidelines
* Use [TortoiseGit](https://tortoisegit.org/), [GitHub Desktop](https://desktop.github.com/), or the git CLI to clone/push/pull from this repository. Do *not* use an SVN client!

* When committing, provide a helpful message in the imperative form (i.e., when this commit is applied, X will happen), such as "Add script for enemy movemement" or "Update texture for Samus run animation" or "Fix animation controller glitch when jumping". Avoid committing several unrelated things in a single commit.

* When committing assets within the Unity project directory, make sure you commit the **.meta** files as well, as they contain information necessary for the project to work correctly.

* Merging changes to scenes/levels in Unity is reportedly a nightmare, so any testing or experimentation should be done in your own personal test scene. Name it "FirstNameTestScene" (Example: JeremyTestScene). The designated game design director (or someone they delegate) will handle the construction of the main game levels.

## Asset Folder Structure
When adding assets to the Unity project, please adhere to the following folder structure:
* Scenes - scenes/levels 
* Scripts - C# scripts
* Art - textures, effects, etc.
* Sound - audio files, sound cues, etc.

The director of each department should consult with the technical director on the organization of subfolders within these folders.

## Project Management
The Trello task board for this project can be found [here](https://trello.com/b/5O3iGqa9/metroid-game-tasks). Create tasks and report bugs there.
