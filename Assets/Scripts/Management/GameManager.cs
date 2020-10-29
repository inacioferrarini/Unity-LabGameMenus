using LabGameMenus.Scenes.Loader;
using UnityEngine;

namespace LabGameMenus.Management {

	public partial class GameManager {

		#region Private Variables

		private static GameManager _instance = null;
		private GameSceneManager gameSceneManager;

		#endregion

		#region Singleton Access

		public static GameManager Instance {
			get {
				if (_instance == null) {
					_instance = new GameManager();
				}
				return _instance;
			}
		}

		#endregion

		#region Initialization

		private GameManager() {
			gameSceneManager = new GameSceneManager();
		}

		#endregion

		#region Public Methods - Menu Interaction

		public void NewGame() {
			// TODO: Updage game status
			gameSceneManager.LoadFirstScene();
		}

		public void LoadGame(string saveGameFilePath) {
			Debug.Log("LOAD GAME: " + saveGameFilePath);
		}

		public void QuitGame() {
			Debug.Log("QUIT GAME");
		}

		#endregion

		#region Public Methods - Scene Loader

		public void Configure(SceneLoaderController sceneLoaderController) {
			gameSceneManager.Configure(sceneLoaderController);
		}

		#endregion

		#region Public Methods - Game Lifecycle

		public void PlayerDied() {
			// TODO: Updage game status
			gameSceneManager.LoadScene(NonGameScene.MenuScene);
		}

		public void PauseGame() {
			// TODO: Updage game status
			gameSceneManager.ShowPauseScene();
		}

		public void ResumeGame() {
			// TODO: Updage game status
			gameSceneManager.HidePauseScene();
		}

		#endregion

	}

}
