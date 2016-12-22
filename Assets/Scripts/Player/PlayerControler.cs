using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerControler : MonoBehaviour {

    public GameObject Inventory;
    public GameObject Player;
    public float XP;
    public bool facingright;
    public float FortitudoLevel = 1;
    public float PernicitasLevel = 1;
    public float IntelligentiaLevel = 1;
    public float CharismaLevel = 1;
    public float PraecantatioLevel = 1;

    public float BasePower = 5;
    public float BaseMpower = 0;
    public float BaseDefence = 5;
    public float BaseMdefence = 0;
    public float BaseSpeed = 4;

    public float Level;
    public float Power;
    public float Mpower;
    public float Defence;
    public float Mdefence;
    public float Speed;
    public float Gold;
    void Start()
    {
        facingright = true;
    }

    void Update() {
        //Movement of the player

        if (Input.GetAxisRaw("Horizontal") > 0.5f)
        {
            transform.Translate(new Vector3(Input.GetAxisRaw("Horizontal") * Speed * Time.deltaTime, 0f, 0f));
            transform.localScale = new Vector3(1, 1, 1);
        }
        if (Input.GetAxisRaw("Horizontal") < -0.5f)
        {
            transform.Translate(new Vector3(-Input.GetAxisRaw("Horizontal") * Speed * Time.deltaTime, 0f, 0f));
            transform.localScale = new Vector3(-1, 1, 1);
        }
        if (Input.GetAxisRaw("Vertical") > 0.5f )
        {
            transform.Translate(new Vector3(0f, Input.GetAxisRaw("Vertical") * Speed * Time.deltaTime, 0f));
        }
        if (Input.GetAxisRaw("Vertical") < -0.5f)
        {
            transform.Translate(new Vector3(0f, Input.GetAxisRaw("Vertical") * Speed * Time.deltaTime, 0f));

        }
        Level = Mathf.Round((FortitudoLevel + PernicitasLevel + IntelligentiaLevel + CharismaLevel + PraecantatioLevel) / 5f);

        //calculating the stats of the player
        Power = BasePower; //+items and powerups
        Defence = BaseDefence;
        Mpower = BaseMpower;
        Mdefence = BaseMdefence;
        Speed = BaseSpeed;

    }
    
}
