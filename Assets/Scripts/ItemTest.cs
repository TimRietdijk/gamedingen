using UnityEngine;
using System.Collections;

public class ItemTest : MonoBehaviour {
    public Inventory script;

	void Start () {
	
	}

    // Update is called once per frame
    public void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "giveitem")
        {
            Debug.Log("item added");
            script.itemgive();
        }
            
    }

}
