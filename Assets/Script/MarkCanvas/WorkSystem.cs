using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class WorkSystem : MonoBehaviour {


    public PlayerStatus status;

    public Text MoneyText;

    public ShowMarkDetail MarkDetail;

    public StatusBarControl StatusBar;

    public Canvas MarkDetailCanvas;


    public GameObject KnowledgeBar;
    public GameObject CourageBar;
    public GameObject DexterityBar;
    public GameObject GentlenessBar;
    public GameObject CharmBar;

    public InformationSystem infor;
    void Start () 
    {
        Button button = GetComponent<Button>();
        button.onClick.AddListener(WorkClick);
	}
	
	void WorkClick () 
    {
        if (MarkDetail.DistanceCheck())
        {
            StatusBar.EnergyBar.GetComponent<EnergyBar>().valueCurrent -= 10;
            StatusBar.NewDate();
            status.HaveMoney += MarkDetail.WorkPay;
            MoneyText.text = "Money:" + status.HaveMoney.ToString();
            status.SaveMoney();
            MarkDetailCanvas.enabled = false;
            infor.informationStandby("You got " + MarkDetail.WorkPay);
            Invoke("PulsParameter", 3f);
        }
	}

    void PulsParameter()
    {
        infor.informationStandby("Your parameter up");
        switch (Random.Range(0, 5))
        {
            case 0:
                KnowledgeBar.GetComponent<EnergyBar>().valueCurrent++;
                break;
            case 1:
                CourageBar.GetComponent<EnergyBar>().valueCurrent++;
                break;
            case 2:
                DexterityBar.GetComponent<EnergyBar>().valueCurrent++;
                break;
            case 3:
                GentlenessBar.GetComponent<EnergyBar>().valueCurrent++;
                break;
            case 4:
                CharmBar.GetComponent<EnergyBar>().valueCurrent++;
                break;
        }
    }
}
