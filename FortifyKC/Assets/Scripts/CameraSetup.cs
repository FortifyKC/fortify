using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CameraSetup : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Camera cm = Camera.main;
		cm.orthographicSize = Screen.width / 2;

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
