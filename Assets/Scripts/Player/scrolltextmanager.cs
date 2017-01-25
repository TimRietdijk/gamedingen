using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class scrolltextmanager : MonoBehaviour {

    private static scrolltextmanager instance;

    public float speed;
    public float fadetime;
    public Vector3 direction;

    public GameObject Player;
    public GameObject statscanvas;
    public GameObject Battletext;
    public RectTransform canvastransform;

    void Start()
    {

    }

    void Update()
    {

    }


    public void Set(string _IDs)
    {
        if (canvastransform == null)
        {
            Player = GameObject.Find(_IDs);
            statscanvas = Player.transform.FindChild("Canvas - stats - map").gameObject;
            canvastransform = statscanvas.GetComponent<RectTransform>();
            return;
        }
    }

    public static scrolltextmanager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = GameObject.FindObjectOfType<scrolltextmanager>();

            }
            return instance;
        }
    }

    public void CreateText(Vector3 position, string text, Color color)
    {
        GameObject battletext = (GameObject)Instantiate(Battletext, position, Quaternion.identity);
        battletext.transform.SetParent(canvastransform);

        battletext.GetComponent<RectTransform>().localPosition = new Vector3(0, 20, 0);
        battletext.GetComponent<scrolltext>().Initialize(speed, direction, fadetime);
        battletext.GetComponent<Text>().text = text;
        battletext.GetComponent<Text>().color = color;
    }
}
