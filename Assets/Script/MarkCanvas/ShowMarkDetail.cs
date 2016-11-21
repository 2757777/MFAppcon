using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ShowMarkDetail : MonoBehaviour {

    public MarkData MD;

    public Text MarkName;
    public Image MarkImage;
    public Text MarkOpenText;

    public GameObject StarImage;
    public Transform StarParent;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void RefreshData()
    {
        MarkName.text = MD.MarkName;
        //add MarkStar
        for (int i = 0; i < MD.MarkRating; i++)
        {
            GameObject NewStar = Instantiate(StarImage);
            NewStar.transform.SetParent(StarParent);
        }

        //LoadImage
        if (MD.MarkPhoto != "")
        {
            StartCoroutine(LoadImage());
        }

        //OpenCheck
        if (MD.OpenCheck != null)
        {
            if (MD.OpenCheck)
            {
                MarkOpenText.text = "Open Now";
                MarkOpenText.color = new Color32(51,255,0,255);
            }
            else
            {
                MarkOpenText.text = "Close Now";
                MarkOpenText.color = new Color32(255, 0, 0, 255);
            }
        }
    }

    IEnumerator LoadImage()
    {
        MarkImage.sprite = null;
        WWW www = new WWW(MD.MarkPhoto);
        yield return www;
        MarkImage.sprite = Sprite.Create(www.texture,new Rect(0, 0, www.texture.width, www.texture.height), new Vector2(0, 0));
    }

}
