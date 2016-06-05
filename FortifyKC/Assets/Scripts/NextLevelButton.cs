using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class NextLevelButton : MonoBehaviour {

	public void nextLevel(int index)
	{
		SceneManager.LoadScene (index);
	}
}
