using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;


public class PlayerSetup : NetworkBehaviour {

    [SerializeField]
    Behaviour[] componentsToDisable;

    [SerializeField]
    string remoteLayerName = "Remote Player";

    public PlayerControler PlayerControler;
    Camera scenecamera;
    public string PlayerNetworkID;
    public GameObject Player;
    public GameObject Character;
    public GameObject Canvas;


    void Start()
    {
        PlayerNetworkID = GetComponent<NetworkIdentity>().netId.ToString();
        string _ID = "Player " + PlayerNetworkID;
        transform.name = _ID;
        Player = GameObject.Find(_ID);
        Canvas = Player.transform.FindChild("Canvas").gameObject;
       
        PlayerControler = Player.GetComponentInChildren<PlayerControler>();
        PlayerControler.Validation(_ID);
        Character = GameObject.Find("Character" + _ID).gameObject;
        if (SceneManager.GetActiveScene().name == "Multiplayer Arena")
        {
            if (!isLocalPlayer)
            {
                DisableComponents();
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

    void DisableComponents()
    {
        Debug.Log("Remote Player assigned");
        gameObject.layer = LayerMask.NameToLayer(remoteLayerName);
        Character.layer = LayerMask.NameToLayer(remoteLayerName);
        for (int i = 0; i < componentsToDisable.Length; i++)
        {
            componentsToDisable[i].enabled = false;
            Canvas.gameObject.SetActive(false);

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
