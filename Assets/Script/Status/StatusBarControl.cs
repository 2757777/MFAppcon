using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using Timers;

public class StatusBarControl : MonoBehaviour {

    public GameObject HungryBar;
    public GameObject HappyBar;
    public GameObject HealthBar;
    public GameObject EnergyBar;
    public GameObject GameManger;

    PlayerStatus Status;
    public Text HungryPointText;
    public Text HappyPointText;
    public Text HealthPointText;
    public Text EnergyPointText;
    public Text MoneyText;

    public InformationSystem infor;
	void Start () {

        //起動
        Status = GameManger.GetComponent<PlayerStatus>();
        if (PlayerPrefs.GetInt(Status.hungry) > 0)
        {
            HungryBar.GetComponent<EnergyBar>().valueCurrent = PlayerPrefs.GetInt(Status.hungry);
            HappyBar.GetComponent<EnergyBar>().valueCurrent  = PlayerPrefs.GetInt(Status.happy);
            HealthBar.GetComponent<EnergyBar>().valueCurrent = PlayerPrefs.GetInt(Status.health);
            EnergyBar.GetComponent<EnergyBar>().valueCurrent = PlayerPrefs.GetInt(Status.energy);
            Status.HaveMoney = PlayerPrefs.GetInt(Status.money);
            MoneyText.text = "Money:" + Status.HaveMoney;
            NewDate();
        }
        else
        {
            //初回起動
            Status.HaveMoney = 1000;
            MoneyText.text = "Money:1000";
            HungryBar.GetComponent<EnergyBar>().valueCurrent = 100;
            HappyBar.GetComponent<EnergyBar>().valueCurrent  = 100;
            HealthBar.GetComponent<EnergyBar>().valueCurrent = 100;
            EnergyBar.GetComponent<EnergyBar>().valueCurrent = 100;

            Status.SaveMoney();

            Status.SaveStateData(HappyBar.GetComponent<EnergyBar>().valueCurrent,
                             HungryBar.GetComponent<EnergyBar>().valueCurrent,
                             HealthBar.GetComponent<EnergyBar>().valueCurrent,
                             EnergyBar.GetComponent<EnergyBar>().valueCurrent);
        }
        //30秒一回Hungry-1
        TimersManager.SetLoopableTimer(this, 30f, HungryExpend);

        //60秒一回happyチェック
        TimersManager.SetLoopableTimer(this, 60f, HappyCheck);

        //180秒一回Health--
        TimersManager.SetLoopableTimer(this, 90f,HealthExpend);

        //30秒一回TEXT更新
        TimersManager.SetLoopableTimer(this, 30f, NewDate);

	}
	

   public void NewDate()
    {
        HungryPointText.text = HungryBar.GetComponent<EnergyBar>().valueCurrent + "%";

        HappyPointText.text = HappyBar.GetComponent<EnergyBar>().valueCurrent + "%";

        HealthPointText.text = HealthBar.GetComponent<EnergyBar>().valueCurrent + "%";

        EnergyPointText.text = EnergyBar.GetComponent<EnergyBar>().valueCurrent + "%";

        Status.SaveStateData(HappyBar.GetComponent<EnergyBar>().valueCurrent, 
                             HungryBar.GetComponent<EnergyBar>().valueCurrent, 
                             HealthBar.GetComponent<EnergyBar>().valueCurrent,
                             EnergyBar.GetComponent<EnergyBar>().valueCurrent);
    }
    void HungryExpend()
    {
        if (HungryBar.GetComponent<EnergyBar>().valueCurrent > 1)
        {
            HungryBar.GetComponent<EnergyBar>().valueCurrent--;
        }
    }

    void HappyCheck()
    {
        if (HappyBar.GetComponent<EnergyBar>().valueCurrent > 1)
        {
            int HungryPoint = HungryBar.GetComponent<EnergyBar>().valueCurrent;
            int HealthPoint = HealthBar.GetComponent<EnergyBar>().valueCurrent;
            //Hungry関連
            if (HungryPoint < 90)
            {
                HappyBar.GetComponent<EnergyBar>().valueCurrent--;
                if (HungryPoint < 75)
                {
                    HappyBar.GetComponent<EnergyBar>().valueCurrent -= 2;
                    if (HungryPoint < 60)
                    {
                        HappyBar.GetComponent<EnergyBar>().valueCurrent -= 3;
                        if (HungryPoint < 30)
                        {
                            HappyBar.GetComponent<EnergyBar>().valueCurrent -= 5;
                        }
                    }
                }
            }
            else if (HungryPoint < 100)
            {
                HappyBar.GetComponent<EnergyBar>().valueCurrent += 3;
            }
            //Health関連
            if (HealthPoint < 80)
            {
                HappyBar.GetComponent<EnergyBar>().valueCurrent--;
                if (HealthPoint < 50)
                {
                    HappyBar.GetComponent<EnergyBar>().valueCurrent -= 3;
                }
            }

        }
    }

    void HealthExpend()
    {
        if (HealthBar.GetComponent<EnergyBar>().valueCurrent > 1)
        {
            HealthBar.GetComponent<EnergyBar>().valueCurrent--;
        }
    }
    void EnergyPlus()
    {
        if (EnergyBar.GetComponent<EnergyBar>().valueCurrent < 100)
        {
            EnergyBar.GetComponent<EnergyBar>().valueCurrent += 10;
            NewDate();
        }
    }

   public void TouchIconPlus(TouchIconSystem.TouchIconType IconType)
    {
        switch (IconType)
        {
            case TouchIconSystem.TouchIconType.Energy:
                infor.informationStandby("Your energy has recovered");
                EnergyPlus();
                break;
            case TouchIconSystem.TouchIconType.Happy:
                infor.informationStandby("You feel some happy");
                HappyBar.GetComponent<EnergyBar>().valueCurrent += 5;
                NewDate();
                break;
            case TouchIconSystem.TouchIconType.Health:
                infor.informationStandby("You got cured");
                HealthBar.GetComponent<EnergyBar>().valueCurrent += 5;
                NewDate();
                break;
            case TouchIconSystem.TouchIconType.Hungry:
                infor.informationStandby("You got some food");
                HungryBar.GetComponent<EnergyBar>().valueCurrent += 10;
                NewDate();
                break;
        }
    }


}
