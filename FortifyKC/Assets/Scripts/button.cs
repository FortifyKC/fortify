using UnityEngine;
using System.Collections;

public class button : MonoBehaviour {
	NextLevelButton next;

	// Use this for initialization
	void Start () {
		next = new NextLevelButton();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI(){
		if(GUI.Button(new Rect(0, 0, 1000, 1000), "PUSH ME")){
			next.nextLevel (4);
		}
	}
}
