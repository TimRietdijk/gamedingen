using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class slotscript : MonoBehaviour {

    public float hover;
    public float leaving;

    public void Hover ()
    {
        GetComponent<Image>().color = new Color (hover, 1, 1, 1);
    }
    public void leave()
    {
        GetComponent<Image>().color = new Color(leaving, 1, 1, 1);
    }
}
