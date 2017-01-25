using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;


public class PlayerSetup : NetworkBehaviour {

    [SerializeField]
    Behaviour[] componentsToDisable;

    public PlayerControler PlayerControler;
    Camera scenecamera;
    public string PlayerNetworkID;
    public GameObject Player;


    void Start()
    {
            PlayerNetworkID = GetComponent<NetworkIdentity>().netId.ToString();
            string _ID = "Player " + PlayerNetworkID;
            transform.name = _ID;
            Player = GameObject.Find(_ID);
            PlayerControler = Player.GetComponentInChildren<PlayerControler>();
            PlayerControler.Validation(_ID);
        if (SceneManager.GetActiveScene().name == "Multiplayer Arena")
        {
            if (!isLocalPlayer)
            {
                for (int i = 0; i < componentsToDisable.Length; i++)
                {
                    componentsToDisable[i].enabled = false;
                }
            }
            else
            {
                scenecamera = Camera.main;
                if (scenecamera != null)
                {
                    scenecamera.gameObject.SetActive(false);
                }
            }
        }
        
    }  

    void OnDisable()
    {
        if (scenecamera != null)
        {
            scenecamera.gameObject.SetActive(true);
        }
    }
}
