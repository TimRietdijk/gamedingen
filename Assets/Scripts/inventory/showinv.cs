using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class showinv : MonoBehaviour {
    public GameObject Player;
    public GameObject InventoryCanvas;
    public Canvas canvasren;
    public int show = 0;

    public void setupinventory(string _IDs)
    {
        Player = GameObject.Find(_IDs);
        InventoryCanvas = Player.transform.FindChild("Canvas").gameObject;
        canvasren = InventoryCanvas.GetComponent<Canvas>();


    }
    void Update()
    { 
        if (Input.GetKeyDown(KeyCode.I) && show == 0)
        {
            canvasren.enabled = true;
            show = 1;
        }

        else if (Input.GetKeyDown(KeyCode.I) && show == 1)
        {
            canvasren.enabled = false;
            show = 0;
        }
    }
    public void closeinv()
    {
        canvasren.enabled = false;
        show = 0;
    }
}
