using LabGameMenus.Management;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace LabGameMenus.Scenes {

	public class GameSceneController: MonoBehaviour {

		#region Menu Event Handling

		public void HandlePlayerDiedAction() {
			GameManager.Instance.PlayerDied();
		}

		public void HandleShowOverlayMenuAction() {
			GameManager.Instance.PauseGame();
		}

		#endregion

	}

}
