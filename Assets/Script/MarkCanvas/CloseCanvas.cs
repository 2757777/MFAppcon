using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CloseCanvas : MonoBehaviour {

    public GameObject CloseObject;
	// Use this for initialization
	void Start () {
        Button button = GetComponent<Button>();
        button.onClick.AddListener(Close);
	}
	
	// Update is called once per frame
    void Close()
    {
        CloseObject.GetComponent<Canvas>().enabled = false;
	}
}
