using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour {

    public GameObject MainCamera;
    public string SceneName;
    public Canvas MarkDetailCanvas;
    public Canvas ToolsPanelCanvas;
    public Canvas StatusCanvas;

    public ShowMarkDetail SMD;
	void Start () 
    {
      Button  button = GetComponent<Button>();
        button.onClick.AddListener(ShowScene);

	}

    void ShowScene()
    {
        if (SMD.DistanceCheck())
        {
            MainCamera.SetActive(false);
            MarkDetailCanvas.enabled = false;
            ToolsPanelCanvas.enabled = false;
            StatusCanvas.enabled = false;
            SceneManager.LoadScene(SceneName, LoadSceneMode.Additive);
        }
    }

    void BackScene()
    {
        MainCamera.SetActive(true);
        MarkDetailCanvas.enabled = true;
        ToolsPanelCanvas.enabled = true;
        StatusCanvas.enabled = true;
        SceneManager.UnloadScene("ScanCamear");
    }
}
