using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PushKeyWord : MonoBehaviour {

    public bool IsPointKeyWord;
	// Use this for initialization
	void Start () {
        Button button = GetComponent<Button>();
        button.onClick.AddListener(BackToMain);
	}
	
    void BackToMain()
    {
        GameObject.Find("CameraPlane").GetComponent<WebCamTextureToCloudVision>().webcamTexture.Stop();
        GameObject.Find("ScanButton").GetComponent<SceneLoader>().BackScene(IsPointKeyWord);
    }
}
