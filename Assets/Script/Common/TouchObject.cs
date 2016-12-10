using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TouchObject : MonoBehaviour {

    public GameObject MarkDetailPrefab;
  //  public Image ScanButtonImage;
   // System.DateTime LastTime;

    public StatusBarControl Status;

    public GameObject Player;

    public Canvas NpcCanvas;

    public GameObject NpcCamear;
	// Use this for initialization
	void Start () 
    {
       // LastTime = System.DateTime.Now;

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
                else 
                    if (obj.tag == "CheckIn")
                {
                    CheckIn(obj);
                }
                 else if(obj.tag == "Question")
                {
                    Debug.Log("touch!");
                    checkQuest(obj);
                }
            }
        }
    }

    void OpenMarkDetail(GameObject TouchObj)
    {
        MarkDetailPrefab.GetComponent<Canvas>().enabled =true;
        MarkDetailPrefab.GetComponent<ShowMarkDetail>().MD = TouchObj.GetComponent<MarkData>();
        MarkDetailPrefab.GetComponent<ShowMarkDetail>().MDPostion = TouchObj.transform.position;
        MarkDetailPrefab.GetComponent<ShowMarkDetail>().SendMessage("RefreshData");
        MarkDetailPrefab.GetComponent<Canvas>().enabled = true;
    }

    void CheckIn(GameObject TouchObj)
    {
       TouchIconSystem.TouchIconType tTyep = TouchObj.GetComponent<TouchIconSystem>().IconType;
       Status.TouchIconPlus(tTyep);
        Destroy(TouchObj);
    }
    void checkQuest(GameObject TouchObj)
    {
        float dis = Vector3.Distance(Player.transform.position, TouchObj.transform.position);
        if (dis < 45)
        {
            NpcCanvas.enabled = true;
            GameObject npcCamear = Instantiate(NpcCamear);
            npcCamear.transform.SetParent(TouchObj.transform.parent);
            npcCamear.transform.localPosition = new Vector3(0, 1.2f, 5);
        }


    }
}
