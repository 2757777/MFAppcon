using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class StartLoad : MonoBehaviour {

    public GameObject ChoosePlayer;

    public GameObject PlayerParent;
    public GameObject MainCamer;

    public Canvas Status;
    public Canvas ToolsPanel;
	// Use this for initialization
	void Start () {


	}
	
	void SendPlayerStart () {

        MainCamer.SetActive(true);
        GameObject Player = Instantiate(ChoosePlayer);
        Player.transform.SetParent(PlayerParent.transform);
        Player.transform.position = new Vector3(63.21f, 0, 75.56f);
        Player.transform.localScale = new Vector3(1, 1, -1);

        Status.enabled = true;
        ToolsPanel.enabled = true;
	}
}
