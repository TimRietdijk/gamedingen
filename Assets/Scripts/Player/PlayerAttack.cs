using UnityEngine;
using System.Collections;

public class PlayerAttack : MonoBehaviour {
    private bool Attacking = false;
    public PlayerControler playercontroler;
    public GameObject Player;
    public GameObject Character;
    public float attackTimer = 0;
    public float attackCD = 0.3f;
    public GameObject Attackrange;
    public Collider2D AttackTrigger;

    public void SetAttack(string IDs) {
        Player = GameObject.Find(IDs);
        Character = Player.transform.FindChild("Character" + IDs).gameObject;
        playercontroler = Character.GetComponent<PlayerControler>();
        Attackrange = Character.transform.FindChild("AttackRange").gameObject;
        AttackTrigger = Attackrange.GetComponent<BoxCollider2D>();
        AttackTrigger.enabled = false;
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.Space) && !Attacking)
        {
            Attacking = true;
            attackTimer = attackCD;
            AttackTrigger.enabled = true;
           
            
        }

        if (Attacking)
        {
            if (attackTimer > 0)
            {
                attackTimer -= Time.deltaTime;
            }
            else
            {
                Attacking = false;
                AttackTrigger.enabled = false;
            }
        }
    }
}
