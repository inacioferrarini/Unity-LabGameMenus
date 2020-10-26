using System.Collections;
using LabGameMenus.Management;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace LabGameMenus.Scenes {

	public class SceneLoaderController: MonoBehaviour {

		#region Public Properties

		public string LoadScenePath { get; set; } = null;

		public GameObject progressSlider;
		public GameObject loadingLabel;
		public GameObject continueLabel;

		[System.Serializable]
		public class SceneLoadingCompletedEvent: UnityEvent { }
		public SceneLoadingCompletedEvent OnSceneLoadingCompleted;

		#endregion

		#region Private Properties

		private AsyncOperation loadSceneOperation = null;

		#endregion

		#region Unity Lifecycle

		private void Awake() {
			GameManager.Instance.Configure(this);
		}

		private void Start() {
			if (LoadScenePath == null) return;
			Debug.Log("SceneLoaderController::Start(). ScenePath = " + LoadScenePath);
			loadSceneOperation = SceneManager.LoadSceneAsync(LoadScenePath);
			loadSceneOperation.allowSceneActivation = false;
		}

		private void Update() {
			if (loadSceneOperation == null) return;
			Debug.Log("SceneLoaderController::Update()");

			float progress = loadSceneOperation.progress;

			UpdateProgress(progress);

			if (Mathf.Approximately(progress, 0.9f)) {
				StartCoroutine(HideProgressAndShowLabel());

				if (continueLabel.activeSelf && Input.GetButtonDown("Jump")) {
					if (OnSceneLoadingCompleted != null) {
						OnSceneLoadingCompleted.Invoke();
					}
					loadSceneOperation.allowSceneActivation = true;
				}
			}
		}

		private void UpdateProgress(float progress) {
			Slider slider = progressSlider.GetComponent<Slider>();
			slider.value = Mathf.Clamp01(progress / 0.9f);
		}

		private IEnumerator HideProgressAndShowLabel() {
			yield return new WaitForSeconds(1f);
			loadingLabel.SetActive(false);
			progressSlider.SetActive(false);
			continueLabel.SetActive(true);
		}

		#endregion

	}

}
