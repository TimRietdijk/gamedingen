using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class showinv : MonoBehaviour {
    public GameObject canvasren;
    public int show = 0;
    public showskill showskill;

    void Start()
    {
        canvasren.GetComponent<Canvas>().enabled = false;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I) && show == 0)
        {
            canvasren.GetComponent<Canvas>().enabled = true;
            show = 1;
            if (showskill.skillshow == 1)
                showskill.closeskill();
        }

        else if (Input.GetKeyDown(KeyCode.I) && show == 1)
        {
            canvasren.GetComponent<Canvas>().enabled = false;
            show = 0;
        }
    }
    public void closeinv()
    {
        canvasren.GetComponent<Canvas>().enabled = false;
        show = 0;
    }
}
