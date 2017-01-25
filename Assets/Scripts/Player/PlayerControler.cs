using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class PlayerControler : MonoBehaviour {
    public Inventory inv;
    public GameObject Player;
    public GameObject Character;
    public GameObject Inventory;
    public GameObject Camera;
    public GameObject statscanvas;
    public GameObject StatsPanel;
    public GameObject Battletextmanager;
    public GameObject tooltip;
    public GameObject inventorycanvas;
    public GameObject Attackrange;
    public GameObject shop;
    public GameObject Teleporter;
    public Teleporter teleporter;
    public Image Healthbar;
    public Statsloader Statsloader;
    public CameraControler CameraControler;
    public scrolltextmanager scrolltextmanager;
    public PlayerAttack PlayerAttack;
    public AttackTrigger AttackTrigger;
    public shopdamage shopdamage;
    public Tooltip Tooltip;
    public ItemTest ItemTest;
    private float DamageDelt;
    public string Networkname;
    public string IDs;

    public float XP;
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
    public float Starthealth = 100;

    public float Level;
    public float Power;
    public float Mpower;
    public float Defence;
    public float Mdefence;
    public float Speed;
    public float Gold;
    private float Health;

    void Start() {

    }
    public void Validation(string IDS)
    {
        Health = Starthealth;
        Player = GameObject.Find(IDS);
        if (Player != null)
        {
           RegisterPlayer(IDS);
        }
    }

    void Update() {
        //Movement of the player
        CameraControler.SetCamera(IDs);
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
        Power = BasePower + inv.items[0].Power + inv.items[1].Power + inv.items[2].Power;
        Defence = BaseDefence;
        Mpower = BaseMpower + inv.items[0].Mpower + inv.items[1].Mpower + inv.items[2].Mpower;
        Mdefence = BaseMdefence;
        Speed = BaseSpeed;
        inv.Houi(IDs);
        AttackTrigger.setattack(IDs);
        scrolltextmanager.Set(IDs);
        Tooltip.settooltip(IDs);
        Statsloader.SetupStats(IDs);
        PlayerAttack.SetAttack(IDs);
        CameraControler.SetCamera(IDs);
        
        if (SceneManager.GetActiveScene().name != "Multiplayer Arena")
        {
            teleporter.SetCharacter(IDs);
            shopdamage.shopset(IDs);
        }

        if (Health <= 0)
        {
            Debug.Log("You have been defeated :(");
            Destroy(gameObject);
        }

    }

    void RegisterPlayer(string _ID)
    {
        IDs = _ID;
        transform.name = "Character" + _ID;
        Character = Player.transform.FindChild("Character" + _ID).gameObject;

        
        

        Attackrange = Character.transform.FindChild("AttackRange").gameObject;
        AttackTrigger = Attackrange.GetComponent<AttackTrigger>();
        ItemTest = Character.GetComponent<ItemTest>();
        inventorycanvas = Player.transform.FindChild("Canvas").gameObject;
        tooltip = inventorycanvas.transform.FindChild("Tooltip").gameObject;
        Battletextmanager = Player.transform.FindChild("BattleTextManager").gameObject;
        scrolltextmanager = Battletextmanager.GetComponent<scrolltextmanager>();
        Inventory = Player.transform.FindChild("Inventory").gameObject;
        inv = Inventory.GetComponent<Inventory>();
        statscanvas = Player.transform.FindChild("Canvas - stats - map").gameObject;
        StatsPanel = statscanvas.transform.FindChild("Stats Panel").gameObject;
        Statsloader = StatsPanel.GetComponent<Statsloader>();
        
        Camera = Player.transform.FindChild("Camera").gameObject;
        
        if (SceneManager.GetActiveScene().name != "Multiplayer Arena")
        {
            Teleporter = GameObject.Find("teleporter");
            teleporter = Teleporter.GetComponent<Teleporter>();
            teleporter.SetCharacter(_ID);
            shop = GameObject.Find("Shop");
            shopdamage = shop.GetComponent<shopdamage>();
            shopdamage.shopset(_ID);
        }
        CameraControler = Camera.GetComponent<CameraControler>();
        PlayerAttack = Character.GetComponent<PlayerAttack>();
        Tooltip = tooltip.GetComponent<Tooltip>();
        
        AttackTrigger.setattack(_ID);
        scrolltextmanager.Set(_ID);
        inv.Houi(_ID);
        
        PlayerAttack.SetAttack(_ID);
        Statsloader.SetupStats(_ID);
        CameraControler.SetCamera(_ID);
        Tooltip.settooltip(_ID);
        inv.fillinventory();


    }

    void takeDamage(float takeDamage)
    {
        Healthbar.fillAmount = Health / Starthealth;
        DamageDelt = takeDamage - Defence;
        Health = Health - DamageDelt;


        Debug.Log(DamageDelt + " damage delt. nog " + Health + " health left.");
    }
    

}
