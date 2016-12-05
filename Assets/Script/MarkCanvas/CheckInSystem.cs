using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CheckInSystem : MonoBehaviour {

    public GameObject Player;

    public GameObject Health;
    public GameObject Food;
    public GameObject Energy;
    public GameObject Happy;

    public Canvas MarkDetailCanvas;

    public ShowMarkDetail MarkDetail;
    string DropType;
	void Start () {

        Button button = GetComponent<Button>();
        button.onClick.AddListener(CheckIN);

	}
	
    void CheckIN()
    {
        if (MarkDetail.DistanceCheck())
        {
            DropType = MarkDetail.MDParentType;
            Vector3 playerPostion = Player.transform.position;
            Instantiate(InstantiateType(DropType), new Vector3((playerPostion.x + Random.Range(-20, 20)), playerPostion.y, (playerPostion.z + Random.Range(-20, 20))), Quaternion.identity);
            MarkDetailCanvas.enabled = false;
        }
	}
   GameObject InstantiateType(string type)
    {
        switch (type)
        {
            case "hotel":
                return Energy;

            case "hospital":
                return Health;

            case "park":
                return Happy;

            case "restaurnt":
                return Food;

            case "train_station":
                if(Random.Range(0,2)==0){
                    return Food;
                }
                else
                {
                    return Happy;
                }
            case "convenience_store":
                int n = Random.Range(0, 4);
                return convenienceBack(n);
            default:
                return null;
        }
    }
   GameObject convenienceBack(int n)
   {
       switch (n)
       {
           case 0:
               return Food;
           case 1:
               return Health;
           case 2:
               return Happy;
           case 3:
               return Energy;
           default:
               return null;
       }
    }
}
