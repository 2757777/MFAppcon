using UnityEngine;
using System.Collections;
using Timers;

public class QuestSystem : MonoBehaviour {
    public enum NpcNeed
    {
        food,
        drink,
        sleep,
        play,
        train
    }
    public NpcNeed need;
	void Start () {
	
	}
   public void TouchQuest()
    {
        this.transform.parent.GetComponent<Animator>().SetBool("Set", false);
        this.transform.parent.GetComponent<Animator>().SetBool("LookWatch", false); 
        this.transform.parent.GetComponent<Animator>().SetBool("Run", true);
        TimersManager.SetLoopableTimer(this, 5f,Boom );
    }
   public void Boom()
   {
       Destroy(this.transform.parent.gameObject);
   }
   void OnDisable()
   {
       GameObject NC = GameObject.Find("NpcCanvas");
       if (NC != null)
       {
           NC.GetComponent<NpcCanvasSystem>().Sofar();
       }
   }
    
	
}
