using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class numbers : MonoBehaviour {
    public int number = 0;
    public Text counter;
	// Use this for initialization
	void Start () {
        counter.text = number.ToString();
	}
	
	// Update is called once per frame
	void Update () {
        counter.text = "number: " + number.ToString();
	}

    public void increase() {
        number++;
    }
}
