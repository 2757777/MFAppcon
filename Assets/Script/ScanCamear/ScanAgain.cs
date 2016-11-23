using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScanAgain : MonoBehaviour {
   
    public GameObject CameraPlane;

	void Start () {
        Button button = GetComponent<Button>();
        button.onClick.AddListener(Again);
        
	}
	
    void Again()
    {
        CameraPlane.GetComponent<TreatmentKeyWord>().SendMessage("CleanPrefab");
        CameraPlane.GetComponent<WebCamTextureToCloudVision>().ScanAgainCheck = true;
	}
}
