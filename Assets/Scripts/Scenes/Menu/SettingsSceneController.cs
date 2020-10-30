using UnityEngine;

using LabGameMenus.Management;

namespace LabGameMenus.Scenes {

	public class SettingsSceneController: MonoBehaviour {

		#region Public Properties

		public GameObject settingsPanel;
		public GameObject audioPanel;
		public GameObject inputPanel;
		public GameObject languagePanel;

		#endregion

		#region Menu Event Handling

		public void HandleShowAudioAction() {
			audioPanel.SetActive(true);
			settingsPanel.SetActive(false);
		}

		public void HandleShowInputAction() {
			inputPanel.SetActive(true);
			settingsPanel.SetActive(false);
		}

		public void HandleShowLanguageAction() {
			languagePanel.SetActive(true);
			settingsPanel.SetActive(false);
		}

		public void HandleBackAction() {
			settingsPanel.SetActive(true);
			audioPanel.SetActive(false);
			inputPanel.SetActive(false);
			languagePanel.SetActive(false);
		}

		public void HandleQuitMenuAction() {
			GameManager.Instance.HideSettings();
		}

		#endregion

	}

}