using UnityEngine;
using System.Collections;

public class AttackTrigger : MonoBehaviour {
    public PlayerControler PlayerControler;
    public float Damage;

    void OnTriggerEnter2D(Collider2D coll) {
        if (coll.isTrigger != true && coll.CompareTag("Damageable"))
        {
            coll.SendMessageUpwards("Damage", Damage);
        }
    }
    void Update() {
        Damage = PlayerControler.Power;
    }


}
