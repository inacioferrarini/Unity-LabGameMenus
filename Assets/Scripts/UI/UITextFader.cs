using System.Collections;
using TMPro;
using UnityEngine;

public class UITextFader: MonoBehaviour {

	#region Public Variables

	public float time = 1.5f;

	#endregion

	#region Unity Lifecycle

	private void Start() {
		TextMeshProUGUI textMesh = GetComponent<TextMeshProUGUI>();
		textMesh.color = new Color(textMesh.color.r, textMesh.color.g, textMesh.color.b, 0f);
	}

	private void Update() {
		TextMeshProUGUI textMesh = GetComponent<TextMeshProUGUI>();
		float textAlpha = textMesh.color.a;

		if (textAlpha == 1) {
			StartCoroutine(FadeTextToZeroAlpha(time, textMesh));
		} else if (textAlpha == 0) {
			StartCoroutine(FadeTextToFullAlpha(time, textMesh));
		}
	}

	#endregion

	#region Coroutines

	private IEnumerator FadeTextToFullAlpha(float t, TextMeshProUGUI textMesh) {
		textMesh.color = new Color(textMesh.color.r, textMesh.color.g, textMesh.color.b, 0);
		while (textMesh.color.a < 1.0f) {
			textMesh.color = new Color(textMesh.color.r, textMesh.color.g, textMesh.color.b, textMesh.color.a + (Time.deltaTime / t));
			yield return null;
		}
		textMesh.color = new Color(textMesh.color.r, textMesh.color.g, textMesh.color.b, 1);
	}

	private IEnumerator FadeTextToZeroAlpha(float t, TextMeshProUGUI textMesh) {
		textMesh.color = new Color(textMesh.color.r, textMesh.color.g, textMesh.color.b, 1);
		while (textMesh.color.a > 0.0f) {
			textMesh.color = new Color(textMesh.color.r, textMesh.color.g, textMesh.color.b, textMesh.color.a - (Time.deltaTime / t));
			yield return null;
		}
		textMesh.color = new Color(textMesh.color.r, textMesh.color.g, textMesh.color.b, 0);
	}

	#endregion

}
