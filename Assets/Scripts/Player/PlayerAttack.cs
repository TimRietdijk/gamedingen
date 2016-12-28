using UnityEngine;
using System.Collections;

public class PlayerAttack : MonoBehaviour {
    private bool Attacking = false;

    public float attackTimer = 0;
    public float attackCD = 0.3f;

    public Collider2D AttackTrigger;

    void Start() {
        AttackTrigger.enabled = false;
    }

    void Update() {
        if (Input.GetKeyDown("f") && !Attacking)
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
