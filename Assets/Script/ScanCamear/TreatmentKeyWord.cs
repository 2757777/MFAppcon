using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TreatmentKeyWord : MonoBehaviour
{

    public GameObject KeyWordPrefab;
    public GameObject KeyWordList;
    public Transform child;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void InstantiatePrefab(string KeyWord)
    {
        GameObject KeyWordObject = Instantiate(KeyWordPrefab);

        IList types = GameObject.Find("MarkDetailCanvas").GetComponent<ShowMarkDetail>().Types;

        byte R = (byte)Random.Range(150,255);
        byte G = (byte)Random.Range(150,255);
        byte B = (byte)Random.Range(150,255);
        KeyWordObject.GetComponent<Image>().color = new Color32(R, G, B, 200);

        //子オブジェクトのテキストをキーワードに変更
        KeyWordObject.GetComponentInChildren<Text>().text = KeyWord;

        KeyWordObject.transform.SetParent(KeyWordList.transform);


        for (int i = 0; i < types.Count; i++)
        {
            if (KeyWord == types[i])
            {
                child = KeyWordObject.transform.FindChild("ExclamationMarkImage");
                child.GetComponent<PushKeyWord>().IsPointKeyWord = true;
                child.GetComponent<Image>().enabled = true;
                break;
            }
 
        }

    }
    void CleanPrefab()
    {
        foreach (Transform n in KeyWordList.transform)
        {
            GameObject.Destroy(n.gameObject);
        }

    }
}
