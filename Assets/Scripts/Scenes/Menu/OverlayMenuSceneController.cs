using LabGameMenus.Management;
using UnityEngine;

namespace LabGameMenus.Scenes.Menu {

	public class OverlayMenuSceneController: MonoBehaviour {

		#region Menu Event Handling

		public void HandleResumeGameAction() {
			GameManager.Instance.ResumeGame();
		}

		public void HandleQuiteGameAction() {
			GameManager.Instance.QuitToMainMenu();
		}

		#endregion
	}

}
