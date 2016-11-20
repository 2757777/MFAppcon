using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GetWorldPostion : MonoBehaviour
{

    public Text PostionText;
    public GoMap.LocationManager Location;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        PostionText.text = "latitude=" + Location.currentLocation.latitude + "\nlongitude=" + Location.currentLocation.longitude;
    }
}
