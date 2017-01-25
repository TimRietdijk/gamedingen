using UnityEngine;
using System.Collections;

public class AttackTrigger : MonoBehaviour {
    public PlayerControler PlayerControler;
    public float Damage;
    public GameObject Player;
    public Color textcolor;

    public void setattack(string IDs)
    {
        Player = GameObject.Find("Character" + IDs);
        PlayerControler = Player.GetComponent<PlayerControler>();
    }

    void OnTriggerEnter2D(Collider2D coll) {
        
        if (coll.isTrigger != true && coll.CompareTag("Damageable"))
        {
            coll.SendMessageUpwards("Damage", Damage);
            scrolltextmanager.Instance.CreateText(transform.position, PlayerControler.Power.ToString(), textcolor);
        }
    }
    void Update() {
        Damage = PlayerControler.Power;
        if (Damage > 0)
        {
            textcolor = Color.red;
        }
    }


}