using LabGameMenus.Scenes.Loader;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace LabGameMenus.Management {

	public partial class GameManager {

		#region Public Enums

		public enum GameScene {
			// Games
			GameScene,
			// Else
			None
		};

		public enum NonGameScene {
			// Loader
			SceneLoader,
			// Menu
			LoadGameScene,
			MenuScene,
			OverlayMenuScene,
			// Else
			None
		}

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

			public void ShowPauseScene() {
				SceneManager.LoadSceneAsync(NonGameScene.OverlayMenuScene.GetScenePath(), LoadSceneMode.Additive);
			}

			public void HidePauseScene() {
				SceneManager.UnloadSceneAsync(NonGameScene.OverlayMenuScene.GetScenePath());
			}

			#endregion

			#region Generic Methods

			public void LoadScene(GameScene scene) {
				NextScene = scene;
				SceneManager.LoadSceneAsync(NonGameScene.SceneLoader.GetScenePath());
			}

			public void LoadScene(NonGameScene scene) {
				SceneManager.LoadSceneAsync(scene.GetScenePath());
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
			}

			return scenePath;
		}

		public static string GetScenePath(this GameManager.NonGameScene gameScene) {
			string scenePath = null;

			switch (gameScene) {
				case GameManager.NonGameScene.SceneLoader:
					scenePath = "Scenes/Loader/SceneLoader";
					break;
				case GameManager.NonGameScene.LoadGameScene:
					scenePath = "Scenes/Menu/LoadGameScene";
					break;
				case GameManager.NonGameScene.MenuScene:
					scenePath = "Scenes/Menu/MenuScene";
					break;
				case GameManager.NonGameScene.OverlayMenuScene:
					scenePath = "Scenes/Menu/OverlayMenuScene";
					break;
			}

			return scenePath;
		}

	}

}
