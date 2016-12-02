using UnityEngine;
using System.Collections;

public class PlayerStatus : MonoBehaviour {
   public string happy;
   public string health;
   public string hungry;
   public string energy;
   public string money;
   public string scanCount;
	// Use this for initialization
	void Start () {
	
	}
	
	public void SaveStateData (int ha,int hu,int he) 
    {
        Debug.Log(hu);
        PlayerPrefs.SetInt(happy, ha);
        PlayerPrefs.SetInt(hungry, hu);
        PlayerPrefs.SetInt(health, he);
        PlayerPrefs.Save();
	}
}
