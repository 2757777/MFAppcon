using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MDToggle : MonoBehaviour {
    public GameObject POI;
	void Start () {
	    var toggle = GetComponent<Toggle>();
        toggle.onValueChanged.AddListener(OnValueChanged);

	}

    void OnValueChanged(bool value)
    {
        POI.SetActive(value);
	}
}
