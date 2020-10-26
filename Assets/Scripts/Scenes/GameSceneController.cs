using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LabGameMenus.Scenes {

	public class GameSceneController: MonoBehaviour {

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
