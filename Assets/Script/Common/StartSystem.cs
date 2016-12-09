using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class StartSystem : MonoBehaviour {

    public GameObject[] characterPrefab;
    public GameObject PrefabParent;
    public GameObject player;
    public GameObject NewData;

    public int Number;
    public int IsHaveDatat;

    public GameObject another;

    public StartLoad startLoad;

    void Awake()
    {
       IsHaveDatat = PlayerPrefs.GetInt("haveData");
        Debug.Log(IsHaveDatat);
        if (IsHaveDatat > 0)
        {
            NewData.SetActive(false);
        }
        else
        {
            NewData.SetActive(true);
            Number = PlayerPrefs.GetInt("PlayerNumber");
        }
        SceneManager.LoadScene("MainScene", LoadSceneMode.Additive);
    }

	void Start () {
        startLoad = GameObject.FindObjectOfType<StartLoad>();
        MakeNew();
	}
	
	void Right () 
    {
        Number++;
        if (Number >= 10)
        {
            Number = 0;
        }
        MakeNew();
	}
    void Left ()
    {
        Number--;
        if (Number < 0)
        {
            Number = 9;
        }
        MakeNew();
    }
    void MakeNew()
    {
        if (player != null)
        {
            Destroy(player);
        }
        player = Instantiate(characterPrefab[Number]);
        player.transform.position = new Vector3(0, 3, 0);
        player.transform.localScale = new Vector3(9, 9, -9);
        player.transform.SetParent(PrefabParent.transform);

    }

    void StartGame()
    {
        PlayerPrefs.SetInt("PlayerNumber", Number);
        startLoad.ChoosePlayer = player;
        startLoad.SendMessage("SendPlayerStart");
        UnityEngine.SceneManagement.SceneManager.UnloadScene("StartScene");
        IsHaveDatat = 1;
        PlayerPrefs.SetInt("haveData", IsHaveDatat);

    }
}
