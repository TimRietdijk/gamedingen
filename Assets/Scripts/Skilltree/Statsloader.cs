using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Networking;

public class Statsloader : MonoBehaviour {
    public Text leveltext;
    public Text Powertext;
    public Text Mpowertext;
    public Text Defencetext;
    public Text Mdefencetext;
    public Text Speedtext;
    public Text Goldtext;
    public PlayerControler PlayerControler;
    public GameObject Player;
    public GameObject Character;



    public void SetupStats(string _IDs)
    {
        if (Player == null)
        {
            Debug.Log(_IDs);
            Player = GameObject.Find(_IDs);
            Character = Player.transform.FindChild("Character" + _IDs).gameObject;
            PlayerControler = Character.GetComponent<PlayerControler>();
        }
    }

    void Update () {

        leveltext.text = "Level: " + PlayerControler.Level.ToString();
        Powertext.text = "Power: " + PlayerControler.Power.ToString();
        Defencetext.text = "Defence: " + PlayerControler.Defence.ToString();
        Mpowertext.text = "Magical Power: " + PlayerControler.Mpower.ToString();
        Mdefencetext.text = "Magical Defence: " + PlayerControler.Mdefence.ToString();
        Speedtext.text = "Speed: " + PlayerControler.Speed.ToString();
        Goldtext.text = "gold: " + PlayerControler.Gold.ToString();
 
    }
}
