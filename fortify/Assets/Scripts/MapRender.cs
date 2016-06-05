using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MapRender : MonoBehaviour {

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
		Sprite map;

		LocationInfo info = new LocationInfo();
		lattitude = info.latitude;
		longitude = info.longitude;

		url = "https://maps.googleapis.com/maps/api/staticmap?center=Brooklyn+Bridge,New+York,NY&zoom=13&size=600x300&maptype=roadmap&markers=color:blue%7Clabel:S%7C40.702147,-74.015794&markers=color:green%7Clabel:G%7C40.711614,-74.012318&markers=color:red%7Clabel:C%7C40.718217,-73.998284&key=AIzaSyArgBTD-XC9yLTYyL89qY3BLuTc1XJJ4-8";

		WWW www = new WWW (url);

		while(!www.isDone){}

		Image sprtr = gameObject.GetComponent<Image>();

		sprtr.sprite = Sprite.Create(www.texture, new Rect(0, 0, www.texture.width, www.texture.height), new Vector2(0.5f, 0.5f));

		Debug.Log ("FUCK THE WIDTH: " + www.texture.width);
	}
}
