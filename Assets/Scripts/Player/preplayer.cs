using UnityEngine;
using System.Collections;

public class preplayer : MonoBehaviour {
    public PlayerControler PlayerControler;

	// Use this for initialization
	void Start () {
        PlayerControler = GetComponent<PlayerControler>();
	}
	
	// Update is called once per frame
	void Update () {
        if (transform.name != PlayerControler.IDs)
        {

        }
        else
        {
            transform.name = PlayerControler.IDs;
        }
    }
}
