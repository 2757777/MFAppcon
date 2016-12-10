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

    public InformationSystem infor;
    public bool HaveKeyWord;
    public PlayerItem PI;
	void Start () 
    {
      Button  button = GetComponent<Button>();
        button.onClick.AddListener(ShowScene);

	}

    void ShowScene()
    {
        if (SMD.DistanceCheck())
        {
            HaveKeyWord = false;
            MainCamera.SetActive(false);
            MarkDetailCanvas.enabled = false;
            ToolsPanelCanvas.enabled = false;
            StatusCanvas.enabled = false;
            SceneManager.LoadScene(SceneName, LoadSceneMode.Additive);
        }
    }

   public void BackScene(bool IsKeyWord)
    {
        MainCamera.SetActive(true);
        ToolsPanelCanvas.enabled = true;
        StatusCanvas.enabled = true;
        SceneManager.UnloadScene("ScanCamear");
        if (IsKeyWord)
        {
            if (Random.Range(0, 2) == 0)
            {
                //food
                PI.OwnFood++;
                PI.SaveItem();
                infor.informationStandby("You got a food!");
            }
            else
            {
                //drink
                PI.OwnDrink++;
                PI.SaveItem();
                infor.informationStandby("You got a drink!");
            }
        }
        else
        {
            MarkDetailCanvas.enabled = true;
        }
    }
}
