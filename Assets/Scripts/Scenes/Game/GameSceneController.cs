using LabGameMenus.Management;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace LabGameMenus.Scenes {

	public class GameSceneController: MonoBehaviour {

		#region Unity Lifecycle

		private void Update() {
			Debug.Log("total loaded scenes: " + SceneManager.sceneCount);
		}

		#endregion

		#region Menu Event Handling

		public void HandlePlayerDiedAction() {
			Debug.Log("Player Died");
			GameManager.Instance.PlayerDied();
		}

		public void HandleShowOverlayMenuAction() {
			GameManager.Instance.PauseGame();
		}

		#endregion

	}

}
