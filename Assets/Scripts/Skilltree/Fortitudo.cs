using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Fortitudo : MonoBehaviour {
    public Button abli1;
    public Button abli2;

    void start()
    {
        //abli1.interactable = false;
        abli1.interactable = false;
    }
	void Update () {
	
	}
    public void UnlockSkill1()
    {
        GetComponent<Image>().color = new Color(255, 64, 74, 1);
    }
}
