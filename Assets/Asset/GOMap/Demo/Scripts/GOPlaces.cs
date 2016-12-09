using UnityEngine;
using System.Collections;
using Assets;
//This class uses Google Places webservice API. 
//It's made for demo purpose only, and needs your personal Google Developer API Key. 
//(No credit card is required, visit https://developers.google.com/places/web-service/intro)

namespace GoMap
{

	public class GOPlaces : MonoBehaviour {

		public GOMap goMap;
        public string baseUrl = "https://maps.googleapis.com/maps/api/place/search/json?";
		public string type;
		public string googleAPIkey;
		public GameObject prefab;
		public float queryRadius = 3000;

		public Coordinates lastQueryCenter = null;

		// Use this for initialization
		void Awake () {

			if (googleAPIkey.Length == 0) {
				Debug.LogWarning ("GOPlaces - GOOGLE API KEY IS REQUIRED, GET iT HERE: https://developers.google.com/places/web-service/intro");
				return;
			}

			//register this class for location notifications
			goMap.locationManager.onOriginSet += LoadData;
			goMap.locationManager.onLocationChanged += LoadData;

		}
			
		public void LoadData (Coordinates currentLocation) {//This is called when the location changes

            
			if (lastQueryCenter == null || lastQueryCenter.DistanceFromPoint (currentLocation) >= queryRadius/1.5f && this.gameObject.activeSelf) { //Do the request only if approaching the limit of the previous one
				lastQueryCenter = currentLocation;
                string url = baseUrl + "location=" + currentLocation.latitude + "," + currentLocation.longitude + "&radius=" + queryRadius + "&type=" + type + "&language=ja&sensor=false&key=" + googleAPIkey;
               //string url = "https://maps.googleapis.com/maps/api/place/search/json?location=35.6814,139.7674&radius=3000&types=lodging&language=ja&sensor=false&key=" + googleAPIkey;
				StartCoroutine (LoadPlaces(url));
			}
		}

        public void ToggleLoadData(double latitude, double longitude)
        {
            string url = baseUrl + "location=" + latitude + "," + longitude + "&radius=" + queryRadius + "&type=" + type + "&language=ja&sensor=false&key=" + googleAPIkey;
            StartCoroutine(LoadPlaces(url));

        }

		public IEnumerator LoadPlaces (string url) { //Request the API

			Debug.Log ("GO PLACES URL: " + url);

			var www = new WWW(url);
			yield return www;

			ParseJob job = new ParseJob();
			job.InData = www.text;
			job.Start();

			yield return StartCoroutine(job.WaitFor());
		
			IDictionary response = (IDictionary)job.OutData;

			IList results = (IList)response ["results"];

			foreach (Transform child in transform) {
				GameObject.Destroy (child.gameObject);
			}


            foreach (IDictionary result in results)
            { //This example only takes GPS location and the id of the object. There's lot more, take a look at the places API documentation

                IDictionary location = (IDictionary)((IDictionary)result["geometry"])["location"];
                double lat = (double)location["lat"];
                double lng = (double)location["lng"];

                //			GameObject go = GameObject.Instantiate (prefab);
                //			go.name = (string)result["place_id"];
                //			goMap.dropPin (lat, lng, go);

                Coordinates coordinates = new Coordinates(lat, lng, 0);
                GameObject go = GameObject.Instantiate(prefab);
                go.transform.localPosition = coordinates.convertCoordinateToVector(0);
                go.transform.parent = transform;
                go.name = (string)result["place_id"];

                MarkData MD = go.GetComponent<MarkData>();
                //ID
                MD.MarkID = (string)result["place_id"];
                //Name
                MD.MarkName = (string)result["name"];
                //CheckPhoto
                var photos = (IList)result["photos"];
                if (photos != null)
                {
                    var reference = (IDictionary)photos[0];
                    MD.MarkPhoto = "https://maps.googleapis.com/maps/api/place/photo?maxwidth=400&photoreference=" + (string)reference["photo_reference"] + "&key=" + googleAPIkey;
                }
                //LoadRank
                if (result["rating"] != null)
                {
                    MD.MarkRating = Mathf.Round(float.Parse(result["rating"].ToString()));
                }
                //OpenCheck
                var OpenTIme = (IDictionary)result["opening_hours"];
                if (OpenTIme != null)
                {
                    MD.HaveOpenTime = true;
                    MD.OpenCheck = (bool)OpenTIme["open_now"];
                }
                else
                {
                    MD.HaveOpenTime = false;
                }
                
                MD.MarkType = (IList)result["types"];
                MD.ParentType = type;
            }
		}
	}
}
