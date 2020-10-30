# Unity Lab Game Menus

Lab for Game Menus, including AsyncOperation and Coroutines.

Uses a menu cycle to mirror a real-usage scenario.

MenuScene -> [New Game]: Loads SceneLoader and then GameScene.
MenuScene -> [Load Game]: Loads LoadGameScene.
MenuScene -> [Settings]: Loads SettingsScene.
MenuScene -> [Quit]: Quits game.

GameScene -> [Player Died]: "Kills Player" and returns to MenuScene.
GameScene -> [Show Menu]: Show Overlay Menu.

TODO LoadGameScene ->

SettingsScene -> [Language]: Shows Language Options.
SettingsScene -> [Input]: Shows Input Options.
SettingsScene -> [Audio]: Shows Audio Options.
SettingsScene -> [Back]: Unloads Settings Scene.

Overlay Menu -> [Resume Games]: Unloads Overlay Menu (returns to Scene).
Overlay Menu -> [Quit Game]: Returns to MenuScene.

Unity Version: 2020.1.4f1 Personal.
