using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SetPlayerActive : MonoBehaviour {
    public GameObject[] Player;
    public GameObject Preplayer;
    public GameObject Spawnpoint;

	// Use this for initialization
	void Start () {
        Player = GameObject.FindGameObjectsWithTag("Player");
        if (SceneManager.GetActiveScene().name != "Multiplayer Arena")
        {
            Instantiate(Preplayer, Spawnpoint.transform.position, Spawnpoint.transform.rotation);
        }
    }
	
	// Update is called once per frame
	void Update () {
        Player = GameObject.FindGameObjectsWithTag("Player");
        for (int i = 0; i < Player.Length; i++)
        {
            if (Player[i].activeInHierarchy == false)
            {
                Player[i].SetActive(true);
                break;
            }
        }
	}
}
