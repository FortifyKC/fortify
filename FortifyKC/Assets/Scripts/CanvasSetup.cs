using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CanvasSetup : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Canvas cv = gameObject.GetComponent<Canvas> ();
		RectTransform cvRectTrans = cv.transform as RectTransform;
		cvRectTrans.sizeDelta = new Vector2 (Screen.width, Screen.height);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
