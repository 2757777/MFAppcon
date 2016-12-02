using UnityEngine;
using System.Collections;

public class PlayerStatus : MonoBehaviour {
   public string happy  = "happy";
   public string health = "health";
   public string hungry = "hungry";
   public string energy = "energy";
   public string money = "money";
   public string scanCount = "ScanCount";
	// Use this for initialization
	void Start () {
	
	}
	
	public void SaveStateData (int ha,int hu,int he) 
    {
        PlayerPrefs.SetInt(happy, ha);
        PlayerPrefs.SetInt(hungry, hu);
        PlayerPrefs.SetInt(health, he);
        PlayerPrefs.Save();
        Debug.Log(PlayerPrefs.GetInt(energy));
	}
}
