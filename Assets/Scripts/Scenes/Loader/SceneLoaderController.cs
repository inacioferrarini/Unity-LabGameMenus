using System.Collections;
using LabGameMenus.Management;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace LabGameMenus.Scenes.Loader {

	public class SceneLoaderController: MonoBehaviour {

		#region Public Properties

		public GameManager.GameScene Scene { get; set; }

		public GameObject progressSlider;
		public GameObject loadingLabel;
		public GameObject continueLabel;

		[System.Serializable]
		public class SceneLoadingCompletedEvent: UnityEvent<GameManager.GameScene> { }
		public SceneLoadingCompletedEvent OnSceneLoadingCompleted;

		#endregion

		#region Private Properties

		private AsyncOperation loadSceneOperation = null;
		private bool isSceneLoaded = false;

		#endregion

		#region Unity Lifecycle

		private void Awake() {
			loadSceneOperation = null;
			isSceneLoaded = false;
			GameManager.Instance.Configure(this);
		}

		private void Start() {
			string loadScenePath = Scene.GetScenePath();
			if (loadScenePath == null) return;
			Debug.Log("SceneLoaderController::Start(). ScenePath = " + loadScenePath);
			loadSceneOperation = SceneManager.LoadSceneAsync(loadScenePath);
			loadSceneOperation.allowSceneActivation = false;
		}

		private void Update() {
			if (loadSceneOperation == null) return;
			Debug.Log("SceneLoaderController::Update()");

			float progress = loadSceneOperation.progress;

			UpdateProgress(progress);

			if (Mathf.Approximately(progress, 0.9f) && !isSceneLoaded) {
				Debug.Log("SceneLoaderController::SceneLoaded. Will hide progress and show label");
				isSceneLoaded = true;
				StartCoroutine(HideProgressAndShowLabel());
			}

			if (isSceneLoaded && continueLabel.activeSelf && Input.GetButtonDown("Jump")) {
				Debug.Log("SceneLoaderController::Everything done. Keypressed.");
				if (OnSceneLoadingCompleted != null) {
					OnSceneLoadingCompleted.Invoke(Scene);
				}
				loadSceneOperation.allowSceneActivation = true;
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
