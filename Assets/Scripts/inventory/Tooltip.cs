using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Networking;

public class Tooltip : MonoBehaviour {
    public PlayerControler PlayerControler;
    public Item item;
    public GameObject Player;
    public GameObject Character;
    private string data;
    private GameObject tooltip;
    private string Thing;

    public void settooltip(string IDs)
    {
        Player = GameObject.Find(IDs);
        Character = Player.transform.FindChild("Character" + IDs).gameObject;
        PlayerControler = Character.GetComponent<PlayerControler>();
        tooltip = PlayerControler.tooltip;
        tooltip.SetActive(false);

    }

    void Update()
    {
        if (tooltip.activeSelf)
        {
            tooltip.transform.position = Input.mousePosition;
        }
    }

    public void Activate(Item item)
    {
        this.item = item;
        ConstructDataString();
        tooltip.SetActive(true);
        
    }

    public void Deactivate()
    {
        tooltip.SetActive(false);
    }

    public void ConstructDataString()
    {
        if (item.Equipable > 2)
        {
            Thing = "Item";
        } else if (item.Equipable == 0)
        {
            Thing = "Wapon";
        } else if (item.Equipable == 1)
        {
            Thing = "Armor";
        } else if (item.Equipable == 2)
        {
            Thing = "Artifact";
        }
        data = "<color=#0473f0><b>" + item.Name + "</b></color>\n\n" + item.Description +"<color=#FF0000>\n\nPower: " + item.Power + "</color>\n\n<color=#33CCFF>Magical power: " + item.Mpower + "</color>\n\n<color=#33cc33>" + Thing + "</color>";
        tooltip.transform.GetChild(0).GetComponent<Text>().text = data;
    }
}
