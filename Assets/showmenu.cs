using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class showmenu : MonoBehaviour
{
    public GameObject menuren;
    public int show = 0;
    public showskill showskill;

    void Start()
    {
        menuren.GetComponent<Canvas>().enabled = false;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && show == 0)
        {
            menuren.GetComponent<Canvas>().enabled = true;
            show = 1;
            if (showskill.skillshow == 1)
                showskill.closeskill();
        }

        else if (Input.GetKeyDown(KeyCode.Escape) && show == 1)
        {
            menuren.GetComponent<Canvas>().enabled = false;
            show = 0;
        }
    }
    public void closeinv()
    {
        menuren.GetComponent<Canvas>().enabled = false;
        show = 0;
    }
}
