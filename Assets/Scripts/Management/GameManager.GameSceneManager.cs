﻿using UnityEngine;
using LabGameMenus.Scenes;
using UnityEngine.SceneManagement;

namespace LabGameMenus.Management {

	public partial class GameManager {

		#region Public Enums

		public enum GameScene {
			None,
			GameScene,
			LoadGameScene,
			MenuScene,
			SceneLoader
		};

		#endregion

		private class GameSceneManager {

			#region Public Properties

			public GameScene CurrentScene { get; private set; } = GameScene.None;
			public GameScene NextScene { get; private set; } = GameScene.None;

			#endregion

			#region Scene Loader

			public void Configure(SceneLoaderController sceneLoaderController) {
				sceneLoaderController.LoadScenePath = NextScene.GetScenePath();
				sceneLoaderController.OnSceneLoadingCompleted = new SceneLoaderController.SceneLoadingCompletedEvent();
				sceneLoaderController.OnSceneLoadingCompleted.AddListener(SceneLoadingCompleted);
			}

			public void SceneLoadingCompleted() {
				CurrentScene = NextScene;
				NextScene = GameScene.None;
				Debug.Log("SceneLoadingCompleted. CurrentScene = " + CurrentScene.ToString() + ", NextScene = " + NextScene.ToString());
			}

			#endregion

			#region Public Methods

			public void LoadFirstScene() {
				NextScene = GameScene.GameScene;
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
					scenePath = "Scenes/GameScene";
					break;
				case GameManager.GameScene.LoadGameScene:
					scenePath = "Scenes/LoadGameScene";
					break;
				case GameManager.GameScene.MenuScene:
					scenePath = "Scenes/MenuScene";
					break;
				case GameManager.GameScene.SceneLoader:
					scenePath = "Scenes/SceneLoader";
					break;
			}

			return scenePath;
		}

	}

}