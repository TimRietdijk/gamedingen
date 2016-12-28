using UnityEngine;
using System.Collections;

public class Dummy : MonoBehaviour {
    public float dummyhealth = 500;
    public float Defence = 0;
    private float DamageDelt;

    void Damage(float Damage)
    {
        DamageDelt = Damage - Defence;
        dummyhealth = dummyhealth - DamageDelt;

        //Debug.Log(DamageDelt + " damage gedaan. nog " + dummyhealth + " health over.");
    }

    void Update() {
        if (dummyhealth <= 0)
        {
            Debug.Log(this.name + "was defeated.");
            Destroy(gameObject);
        }
    }
}
