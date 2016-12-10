using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerItem : MonoBehaviour {

    public int OwnFood;
    public int OwnDrink;

    public Text FoodText;
    public Text DrinkText;
	void Start () {
        OwnDrink = PlayerPrefs.GetInt("OwnDrink");
        OwnFood = PlayerPrefs.GetInt("OwnFood");
        FoodText.text = OwnFood.ToString();
        DrinkText.text = OwnDrink.ToString();
	}
   public void SaveItem()
    {
        PlayerPrefs.SetInt("OwnFood", OwnFood);
        PlayerPrefs.SetInt("OwnDrink", OwnFood);

        FoodText.text = OwnFood.ToString();
        DrinkText.text = OwnDrink.ToString();
    }
}
