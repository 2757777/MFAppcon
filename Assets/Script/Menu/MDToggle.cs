using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MDToggle : MonoBehaviour {
    public GameObject POI;
	void Start () {
	    var toggle = GetComponent<Toggle>();
        toggle.isOn = PlayerPrefs.GetInt(this.gameObject.name) != 0;
        toggle.onValueChanged.AddListener(OnValueChanged);
        
	}

    void OnValueChanged(bool value)
    {
        POI.SetActive(value);
        PlayerPrefs.SetInt(this.gameObject.name, value ? 1 : 0);
	}
}
