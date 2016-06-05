using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class NextLevelButton : MonoBehaviour {

	public void nextLevel(int index)
	{
		SceneManager.LoadScene (index);
	}

	void OnGUI(){
		if (GUILayout.Button ("GO TO MAP")) {
			nextLevel (4);
		}
	}
}
