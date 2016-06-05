using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CameraSetup : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Camera cm = gameObject.GetComponent<Camera> ();
		if (cm) {
			cm.orthographicSize = Screen.width / 2;

			RectTransform cmRect = cm.transform as RectTransform;
			cmRect.anchoredPosition = new Vector2 (	Screen.width,
													Screen.height);
		}

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
