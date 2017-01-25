using UnityEngine;
using System.Collections;

public class shopdamage : MonoBehaviour {
    public PlayerControler PlayerControler;
    public Inventory inventory;
    public float takeDamage;
    public GameObject player;
    public GameObject Character;
    public GameObject Inventory;
    public Color textcolor;
    private float textdamage;

    void Start()
    {

    }

    public void shopset (string IDs) {
        player = GameObject.Find(IDs);
        Character = player.transform.FindChild("Character" + IDs).gameObject;
        PlayerControler = Character.GetComponent<PlayerControler>();
        Inventory = GameObject.Find("Inventory").gameObject;
        inventory = Inventory.GetComponent<Inventory>();

	}
	void Update () {
        takeDamage = PlayerControler.Power;
        if (takeDamage > 0)
        {
            textcolor = Color.red;
        }
        textdamage = PlayerControler.Power - PlayerControler.Defence;
    }
    void OnTriggerEnter2D(Collider2D shopper)
    {
        inventory.itemgive();
        if (textdamage < 1)
        {

        }
        else { 
            if (shopper.isTrigger != true && shopper.CompareTag("Character"))
            {
                player.SendMessageUpwards("takeDamage", takeDamage);
                scrolltextmanager.Instance.CreateText(transform.position, textdamage.ToString(), textcolor);
            }
        }
    }
}
