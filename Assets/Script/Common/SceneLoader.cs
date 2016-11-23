using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour {

    public GameObject MainCamera;
    public string SceneName;
    public Canvas MarkDetailCanvas;
	void Start () 
    {
      Button  button = GetComponent<Button>();
        button.onClick.AddListener(ShowScene);

	}
	
    void ShowScene()
    {
        MainCamera.SetActive(false);
        MarkDetailCanvas.enabled = false;
        SceneManager.LoadScene(SceneName, LoadSceneMode.Additive);
	}
}
