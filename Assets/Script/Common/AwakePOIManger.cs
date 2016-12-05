using UnityEngine;
using System.Collections;

public class AwakePOIManger : MonoBehaviour {

    public GameObject ConveniencePOI;
    public GameObject HotelPOI;
    public GameObject HospitalPOI;
    public GameObject ParkPOI;
    public GameObject RestaurntPOI;
    public GameObject StationPOI;

    void Awake()
    {
        ConveniencePOI.SetActive((PlayerPrefs.GetInt("ConvenienceToggle") != 0));
        HotelPOI.SetActive((PlayerPrefs.GetInt("HotelToggle") != 0));
        HospitalPOI.SetActive((PlayerPrefs.GetInt("HospitalToggle") != 0));
        ParkPOI.SetActive((PlayerPrefs.GetInt("ParkToggle") != 0));
        RestaurntPOI.SetActive((PlayerPrefs.GetInt("RestaurantToggle") != 0));
        StationPOI.SetActive((PlayerPrefs.GetInt("SubwayStationToggle") != 0));
	}
	
}
