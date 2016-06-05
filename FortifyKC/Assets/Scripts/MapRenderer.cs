using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MapRenderer : MonoBehaviour {

	// Use this for initialization
	IEnumerator Start () {
		SetTexture ();

		// Check to start location services
		if(!Input.location.isEnabledByUser)
			yield break;

		Input.location.Start(1f, 1f);

		// Wait for Location Services initialization
		waitLocInit(20);
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
			yield break;
		} 

		// Connection has failed
		if (Input.location.status == LocationServiceStatus.Failed)
		{
			print("Unable to determine device location");
			yield break;
		} else {
			print(	"TEST: " + Input.location.lastData.latitude + " " +
				Input.location.lastData.longitude + " " +
				Input.location.lastData.altitude + " " +
				Input.location.lastData.horizontalAccuracy + " " +
				Input.location.lastData.timestamp);
		}
		Debug.Log("Test: " + Input.location.lastData.latitude);
	}

	void OnGUI(){
		GUILayout.Label ("Test: " + Input.location.lastData.latitude);
	}

	void SetTexture(){
		string url = "";
		float lattitude;
		float longitude;

		LocationInfo info = new LocationInfo();
		lattitude = info.latitude;
		longitude = info.longitude;

		url = CreateURL (info);

		WWW www = new WWW (url);

		while(!www.isDone){}

		Image sprtr = gameObject.GetComponent<Image>();

		sprtr.sprite = Sprite.Create(www.texture, new Rect(0, 0, www.texture.width, www.texture.height), new Vector2(0.5f, 0.5f));

		Debug.Log ("FUCK THE WIDTH: " + www.texture.width);
	}

	string CreateURL (LocationInfo info){
		float currentLat = info.latitude;
		float currentLong = info.longitude;
		float zoom = 13;
		int screenHeight = Screen.height;
		int screenWidth = Screen.width;

		string finalURL = "http://maps.google.com/maps/api/staticmap?center=" + currentLat + ","
			+ currentLong + "&zoom=" + zoom + "&size=" + screenWidth + "x" + screenHeight + "&type=hybrid&sensor=true?a.jpg";


		return finalURL;
	}

}
