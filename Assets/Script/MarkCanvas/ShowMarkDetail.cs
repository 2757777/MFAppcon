using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ShowMarkDetail : MonoBehaviour {

    public MarkData MD;

    public GoMap.LocationManager Loction;

    public Text MarkName;
    public Image MarkImage;
    public Text MarkOpenText;

    public GameObject StarImage;
    public Transform StarParent;

    public GameObject TypeList;
    public GameObject TypePrefab;

    public IList Types;

    public StatusBarControl StatusBar;

    //時給計算
    public Button WorkButton;
    public bool Open;
    public int StarBouns;
    public bool ScanBouns;
    public int WorkPay;
    public Text PayText;

    //距離チェック
    public Vector3 MDPostion;

    public GameObject Player;

    public GameObject WarningMark;
 
    void RefreshData()
    {
        MarkName.text = MD.MarkName;
        Open = false;
        StarBouns = 0;
        ScanBouns = false;
        WarningMark.SetActive(false);
        //delete old star
        foreach (Transform n in StarParent.transform)
        {
            GameObject.Destroy(n.gameObject);
        }
        //add MarkStar
        for (int i = 0; i < MD.MarkRating; i++)
        {
            GameObject NewStar = Instantiate(StarImage);
            NewStar.transform.SetParent(StarParent);
            StarBouns++;
        }

        //LoadImage
        if (MD.MarkPhoto != "")
        {
            MarkImage.enabled = true;
            StartCoroutine(LoadImage());
        }
        else
        {
            MarkImage.enabled = false;
        }
        //OpenCheck
        if (MD.HaveOpenTime)
        {
            if (MD.OpenCheck)
            {
                MarkOpenText.text = "Open Now";
                MarkOpenText.color = new Color32(51,255,0,255);
                Open =true;
            }
            else
            {
                MarkOpenText.text = "Close Now";
                MarkOpenText.color = new Color32(255, 0, 0, 255);
            }
        }
        else
        {
            MarkOpenText.text = "unknown";
            MarkOpenText.color = new Color32(255, 0, 0, 255);
        }

        //delete old Type
        foreach (Transform n in TypeList.transform)
        {
            GameObject.Destroy(n.gameObject);
        }

        //Type
        Types = MD.MarkType;

        for (int i = 0; i < MD.MarkType.Count; i++)
        {
            if ((string)MD.MarkType[i] != "point_of_interest" && (string)MD.MarkType[i] != "establishment")//二つの例外
            {
                GameObject NewType = Instantiate(TypePrefab);
                NewType.GetComponent<Text>().text = (string)MD.MarkType[i];
                NewType.transform.SetParent(TypeList.transform);
            }

        }

        //WorkSystem
        if (Open && StatusBar.EnergyBar.GetComponent<EnergyBar>().valueCurrent > 10 && Types[0] != "park")
        {
            WorkButton.interactable = Open;
        }
        else
        {
            WorkButton.interactable = false;
        }
        WorkPay = 950 + 100 * (StarBouns + ScanBouns.GetHashCode());
        PayText.text = "Hourly Pay:\n" + WorkPay;

    }

    IEnumerator LoadImage()
    {
        MarkImage.sprite = null;
        WWW www = new WWW(MD.MarkPhoto);
        yield return www;
        MarkImage.sprite = Sprite.Create(www.texture,new Rect(0, 0, www.texture.width, www.texture.height), new Vector2(0, 0));
    }

    public bool DistanceCheck()
    {
        float dis = Vector3.Distance(Player.transform.position, MDPostion);
        Debug.Log(dis);
        if (dis < 27.5)
        {
            return true;
        }
        else
        {
            WarningMark.SetActive(true);
            return false;
        }
    }

}
