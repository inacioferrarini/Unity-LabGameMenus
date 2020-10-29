using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

using LabGameMenus.Management;

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
			Debug.Log("Show Overlay Menu");
		}

		#endregion

	}

}
