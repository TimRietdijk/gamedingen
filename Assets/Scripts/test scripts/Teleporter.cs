using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Teleporter : MonoBehaviour {
    public GameObject Player;
    public GameObject Character;

    public void SetCharacter(string IDS)
    {
        Player = GameObject.Find(IDS);
        Character = Player.transform.FindChild("Character" + IDS).gameObject;
    }

    void OnTriggerEnter2D(Collider2D player)
    {
           if (player.isTrigger != true && player.CompareTag("Character"))
           {
            SceneManager.LoadScene("Multiplayer Arena");
            Debug.Log("Load scene ...");
           }
       }
}
