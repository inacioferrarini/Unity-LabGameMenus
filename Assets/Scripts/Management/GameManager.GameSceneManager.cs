using LabGameMenus.Scenes.Loader;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace LabGameMenus.Management {

	public partial class GameManager {

		#region Public Enums

		public enum GameScene {
			// Games
			GameScene,
			// Loader
			SceneLoader,
			// Menu
			LoadGameScene,
			MenuScene,
			OverlayMenuScene,
			// Else
			None
		};

		#endregion

		private class GameSceneManager {

			#region Public Properties

			public GameScene CurrentScene { get; private set; } = GameScene.None;
			public GameScene NextScene { get; private set; } = GameScene.None;

			#endregion

			#region Scene Loader

			public void Configure(SceneLoaderController sceneLoaderController) {
				sceneLoaderController.Scene = NextScene;
				sceneLoaderController.OnSceneLoadingCompleted = new SceneLoaderController.SceneLoadingCompletedEvent();
				sceneLoaderController.OnSceneLoadingCompleted.AddListener(SceneLoadingCompleted);
			}

			public void SceneLoadingCompleted(GameScene scene) {
				CurrentScene = scene;
				NextScene = GameScene.None;
				Debug.Log("SceneLoadingCompleted. CurrentScene = " + CurrentScene.ToString() + ", NextScene = " + NextScene.ToString());
			}

			#endregion

			#region Public Methods

			public void LoadFirstScene() {
				LoadScene(GameScene.GameScene);
			}

			public void LoadScene(GameScene scene) {
				NextScene = scene;
				SceneManager.LoadSceneAsync(GameScene.SceneLoader.GetScenePath());
			}

			#endregion

		}

	}

	public static class Extensions {

		public static string GetScenePath(this GameManager.GameScene gameScene) {
			string scenePath = null;

			switch (gameScene) {
				case GameManager.GameScene.GameScene:
					scenePath = "Scenes/Game/GameScene";
					break;
				case GameManager.GameScene.SceneLoader:
					scenePath = "Scenes/Loader/SceneLoader";
					break;
				case GameManager.GameScene.LoadGameScene:
					scenePath = "Scenes/Menu/LoadGameScene";
					break;
				case GameManager.GameScene.MenuScene:
					scenePath = "Scenes/Menu/MenuScene";
					break;
				case GameManager.GameScene.OverlayMenuScene:
					scenePath = "Scenes/Menu/MenuScene";
					break;
			}

			return scenePath;
		}

	}

}
