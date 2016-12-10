using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class NpcCanvasSystem : MonoBehaviour {

    public GameObject NpcCamera;
    public GameObject npcCamear;
    public TouchObject touchObject;

    public Canvas MenuButton;
    public QuestSystem.NpcNeed NeedType;

    public Button OkButtonObject;

    public Text SerifText;
    public Text PlayOwnText;

    QuestSystem QuestTyp;
    public GameObject GameManger;
    PlayerItem PI;
    PlayerStatus PS;
    public EnergyBar energyBar;
    public StatusBarControl SBC;
    public WorkSystem WS;
	// Use this for initialization
	void Start () {
	
	}
   public void TouchNpc(GameObject TouchObj)
    {
        npcCamear = Instantiate(NpcCamera);
        npcCamear.transform.SetParent(TouchObj.transform.parent);
        npcCamear.transform.localPosition = new Vector3(0, 1.2f, 5);
        NeedType = TouchObj.GetComponent<QuestSystem>().need;
        PI = GameManger.GetComponent<PlayerItem>();
        PS = GameManger.GetComponent<PlayerStatus>();
        switch (NeedType)
        {
            case QuestSystem.NpcNeed.food:
                SerifText.text = "I am Very <color=#ff0000ff>hungry</color>. Can you give me some <color=#ff0000ff>food</color>?";
                PlayOwnText.text = "You have food <color=#ff0000ff>" + PI.OwnFood + "</color>";
                OkButtonObject.interactable = PI.OwnFood > 0;
                break;
            case QuestSystem.NpcNeed.drink:
                SerifText.text = "I am Very <color=#ff0000ff>thirst</color>. Can you give me some <color=#ff0000ff>drink</color>?";
                PlayOwnText.text = "You have drink <color=#ff0000ff>" + PI.OwnDrink + "</color>";
                OkButtonObject.interactable = PI.OwnDrink > 0;
                break;
            case QuestSystem.NpcNeed.sleep:
                SerifText.text = "I am Very <color=#ff0000ff>tired</color>. Can you give me <color=#ff0000ff>money 1000</color> to have a rest?";
                PlayOwnText.text = "You have money <color=#ff0000ff>" + PS.HaveMoney + "</color>";
                OkButtonObject.interactable = PS.HaveMoney >= 1000;
                break;
            case QuestSystem.NpcNeed.play:
                SerifText.text = "I am Very <color=#ff0000ff>lonely</color>. Can you Play with me?";
                PlayOwnText.text = "You have Energy <color=#ff0000ff>" + energyBar.valueCurrent + "</color>";
                OkButtonObject.interactable = energyBar.valueCurrent >= 15;
                break;
            case QuestSystem.NpcNeed.train:
                SerifText.text = "I'm going to <color=#ff0000ff>be late</color>. Can you give me <color=#ff0000ff>money 1500</color> for taking the train?";
                PlayOwnText.text = "You have money <color=#ff0000ff>" + PS.HaveMoney + "</color>";
                OkButtonObject.interactable = PS.HaveMoney > 1500;
                break;
            default:
                break;
        }
        this.GetComponent<Canvas>().enabled = true;
        MenuButton.enabled = false;
    }
    void OkButton()
    {
        switch (NeedType)
        {
            case QuestSystem.NpcNeed.drink:
                PI.OwnDrink--;
                PI.SaveItem();
                break;
            case QuestSystem.NpcNeed.food:
                PI.OwnFood--;
                PI.SaveItem();
                break;
            case QuestSystem.NpcNeed.play:
                energyBar.valueCurrent -= 15;
                SBC.NewDate();
                break;
            case QuestSystem.NpcNeed.sleep:
                PS.HaveMoney -= 1000;
                PS.SaveMoney();
                break;
            case QuestSystem.NpcNeed.train:
                PS.HaveMoney -= 1500;
                PS.SaveMoney();
                break;
        }
        WS.PulsParameter();
        NoButton();
    }
    void NoButton()
    {
        touchObject.enabled = true;
        this.GetComponent<Canvas>().enabled = false;
        npcCamear.SetActive(false);
        MenuButton.enabled = true;
    }
	
}
