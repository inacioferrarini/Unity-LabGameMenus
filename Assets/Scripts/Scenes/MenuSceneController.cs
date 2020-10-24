using LabGameMenus.Management;
using UnityEngine;

namespace LabGameMenus.Scenes {

	public class MenuSceneController: MonoBehaviour {

		#region Menu Event Handling

		public void HandleNewGameAction() {
			GameManager.Instance.NewGame();
		}

		public void HandleLoadGameAction() {
			GameManager.Instance.LoadGame("[Path]");
		}

		public void HandleQuitAction() {
			GameManager.Instance.QuitGame();
		}

		#endregion

	}

}
