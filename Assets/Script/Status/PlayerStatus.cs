﻿using UnityEngine;
using System.Collections;

public class PlayerStatus : MonoBehaviour {

    public string happy;
    public string health;
    public string hungry;
    public string energy;
    public string money;
    public string scanCount;
   
    public int HaveMoney;
	void Start () {
	
	}
	
	public void SaveStateData (int ha, int hu, int he, int en) 
    {
        Debug.Log(hu);
        PlayerPrefs.SetInt(happy, ha);
        PlayerPrefs.SetInt(hungry, hu);
        PlayerPrefs.SetInt(health, he);
        PlayerPrefs.SetInt(health, he);
        PlayerPrefs.SetInt(energy, en);
        PlayerPrefs.Save();
	}

    public void SaveMoney()
    {
        PlayerPrefs.SetInt(money, HaveMoney);
    }

    public void SaveEnergy(int en)
    {
        PlayerPrefs.SetInt(energy, en);
    }
}
