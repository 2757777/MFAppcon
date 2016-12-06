using UnityEngine;
using UnityEngine.UI;

public class InformationSystem : MonoBehaviour
{

    public GameObject InformationText;

    public GameObject Parentcanvans;

    private string information;

   public void informationStandby (string infor)
   {
       information = infor;
	    Invoke("DelayMethod", 3.5f);

	}

    void DelayMethod()
    {
        GameObject informationObj =  Instantiate(InformationText);

        informationObj.GetComponent<Text>().text = information;
        informationObj.transform.SetParent(Parentcanvans.transform);

        Destroy(informationObj,3f);
    }

}
