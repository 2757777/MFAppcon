using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class SceneLoader : MonoBehaviour {
    public string SceneName;
	// Use this for initialization
	void Start () 
    {
      Button  button = GetComponent<Button>();
        button.onClick.AddListener(ShowScene);

	}
	
	// Update is called once per frame
    void ShowScene()
    {
        SceneManager.LoadScene(SceneName, LoadSceneMode.Additive);
	}
}
