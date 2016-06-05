using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MapRenderer : MonoBehaviour {
	public float working;

	// Use this for initialization
	IEnumerator Start () {
		working = 0;

		// Check to start location services
		if (!Input.location.isEnabledByUser) {
			working += 1;
			yield break;
		}

		Debug.Log ("SUCK IT");
		Input.location.Start(1f, 1f);

		// Wait for Location Services initialization
		waitLocInit(2);
		SetTexture ();
		working += 2;
	}

	// Update is called once per frame
	void Update () {

	}

	///////////////////////////////////////////////
	/////////////
	///  Purpose: Wait for Location Services initialization  ///
	////////////////////////////////////////////////////////////
	IEnumerator waitLocInit(int maxTime = 0)
	{
		while(Input.location.status == LocationServiceStatus.Initializing && maxTime > 0)
		{
			yield return new WaitForSeconds(1);
			maxTime--;
		}

		if(maxTime < 1)
		{
			print("Location Services initialization timed out.");
		} 

		// Connection has failed
		if (Input.location.status == LocationServiceStatus.Failed)
		{
			Debug.Log ("Cannot get location info");
			yield break;
		} else {
			Debug.Log(	"TEST: " + Input.location.lastData.latitude + " " +
				Input.location.lastData.longitude + " " +
				Input.location.lastData.altitude + " " +
				Input.location.lastData.horizontalAccuracy + " " +
				Input.location.lastData.timestamp);
		}
		Debug.Log("Test: " + Input.location.lastData.latitude);
	}

	void OnGUI(){
		GUILayout.Label ("" + working);
		if(working == 2){
			GUILayout.Label (CreateURL());
		}
	}

	void SetTexture(){
		string url = "";

		url = CreateURL ();

		WWW www = new WWW (url);

		while(!www.isDone){}

		Image sprtr = gameObject.GetComponent<Image>();

		sprtr.sprite = Sprite.Create(www.texture, new Rect(0, 0, www.texture.width, www.texture.height), new Vector2(0.5f, 0.5f));

		Debug.Log ("FORGET THE WIDTH: " + www.texture.width);
	}

	string CreateURL(){
		LocationInfo info = new LocationInfo();

		float currentLat = Input.location.lastData.latitude;
		float currentLong = Input.location.lastData.longitude;
		float zoom = 13;
		int screenHeight = Screen.height;
		int screenWidth = Screen.width;

		string finalURL = "http://maps.google.com/maps/api/staticmap?center=" + currentLat + ","
			+ currentLong + "&zoom=" + zoom + "&size=" + screenWidth + "x" + screenHeight + "&type=hybrid&sensor=true?a.jpg";

		Debug.Log (finalURL);

		return finalURL;
	}

}
