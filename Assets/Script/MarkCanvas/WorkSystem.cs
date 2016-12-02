using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class WorkSystem : MonoBehaviour {


    public PlayerStatus status;

    public Text MoneyText;

    public ShowMarkDetail MarkDetail;

    public StatusBarControl StatusBar;

    void Start () 
    {
        Button button = GetComponent<Button>();
        button.onClick.AddListener(WorkClick);
	}
	
	void WorkClick () 
    {
        StatusBar.EnergyBar.GetComponent<EnergyBar>().valueCurrent -= 10;
        StatusBar.NewDate();
        status.HaveMoney += MarkDetail.WorkPay;
        MoneyText.text = "Money:" + status.HaveMoney.ToString();
        status.SaveMoney();
	}
}
