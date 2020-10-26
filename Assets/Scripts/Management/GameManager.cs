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

		#region Public Methods

		public void NewGame() {
			gameSceneManager.LoadFirstScene();
		}

		public void LoadGame(string saveGameFilePath) {
			Debug.Log("LOAD GAME: " + saveGameFilePath);
		}

		public void QuitGame() {
			Debug.Log("QUIT GAME");
		}

		public void Configure(SceneLoaderController sceneLoaderController) {
			gameSceneManager.Configure(sceneLoaderController);
		}

		#endregion

	}

}
