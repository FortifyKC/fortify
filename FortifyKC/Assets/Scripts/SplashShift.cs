using UnityEngine;
using System.Collections;

public class SplashShift : MonoBehaviour {

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        float seconds = 4;
        while (seconds > 0) {
            seconds -= Time.deltaTime;
        }
        NextLevelButton next = new NextLevelButton();
        next.nextLevel(1);
    }
}
