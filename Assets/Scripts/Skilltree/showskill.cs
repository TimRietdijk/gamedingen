using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class showskill : MonoBehaviour {
    public GameObject skillren;
    public int skillshow = 0;
    public showinv showinv;


    void Start()
    {
        skillren.GetComponent<Canvas>().enabled = false;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K) && skillshow == 0)
        {
            skillren.GetComponent<Canvas>().enabled = true;
            skillshow = 1;
            if (showinv.show == 1)
                showinv.closeinv();

        }

        else if (Input.GetKeyDown(KeyCode.K) && skillshow == 1)
        {
            skillren.GetComponent<Canvas>().enabled = false;
            skillshow = 0;
        }

    }
    public void closeskill()
    {
        skillren.GetComponent<Canvas>().enabled = false;
        skillshow = 0;
    }
}
