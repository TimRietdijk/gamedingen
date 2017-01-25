using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Dummy : MonoBehaviour {
    public float starthealth = 500;
    public float health;
    public float Defence = 0;
    private float DamageDelt;
    public Image Healthbar;

    void Start() {
        health = starthealth;

    }
    
    void Damage(float Damage)
    {
        Healthbar.fillAmount = health / starthealth;
        DamageDelt = Damage - Defence;
        health = health - DamageDelt;

        //Debug.Log(DamageDelt + " damage delt. nog " + dummyhealth + " health left.");
    }

    void Update() {
        if (health <= 0)
        {
            Debug.Log(this.name + "was defeated.");
            Destroy(gameObject);
        }
    }
}
