using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace LabGameMenus.Scenes {

	public class GameSceneController: MonoBehaviour {

		private void Update() {
			Debug.Log("total loaded scenes: " + SceneManager.sceneCount);
		}

		#region Menu Event Handling

		public void HandlePlayerDiedAction() {
			Debug.Log("Player Died");
		}

		public void HandleShowMenuAction() {
			Debug.Log("Show Menu");
		}

		#endregion

	}

}
