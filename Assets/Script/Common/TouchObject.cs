﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TouchObject : MonoBehaviour {

    public Canvas MarkDetailCanvas;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit = new RaycastHit();

            if (Physics.Raycast(ray, out hit))
            {
                GameObject obj = hit.collider.gameObject;
                if (obj.tag == "Mark")
                {
                    OpenMarkDetail(obj);
                }
                Debug.Log(obj.name);
            }
        }
    }

    void OpenMarkDetail(GameObject TouchObj)
    {
        MarkDetailCanvas.GetComponent<ShowMarkDetail>().MD = TouchObj.GetComponent<MarkData>();
        MarkDetailCanvas.GetComponent<ShowMarkDetail>().SendMessage("RefreshData");
        MarkDetailCanvas.enabled = true;
    }
}
