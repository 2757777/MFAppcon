using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MDToggle : MonoBehaviour {
    public GameObject POI;
    public GoMap.GOPlaces GoPlace;
    public GoMap.LocationManager LocationManager;
    void Start () {
	    var toggle = GetComponent<Toggle>();
        toggle.isOn = PlayerPrefs.GetInt(this.gameObject.name) != 0;
        toggle.onValueChanged.AddListener(OnValueChanged);
        
	}

    void OnValueChanged(bool value)
    {
        POI.SetActive(value);
        PlayerPrefs.SetInt(this.gameObject.name, value ? 1 : 0);
        if (value)
        {
            GoPlace.ToggleLoadData(LocationManager.currentLocation.latitude,LocationManager.currentLocation.longitude);
        }
    }
}
