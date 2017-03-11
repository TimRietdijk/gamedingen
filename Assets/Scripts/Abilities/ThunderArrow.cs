using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Events;
using UnityEngine.SceneManagement;


public class ThunderArrow : NetworkBehaviour {
    public string[] damagebleTags;

    public GameObject Player;
    public GameObject Character;
    public Abilities Abilities;

    [SerializeField]
    private GameObject FirePoint;

    [SerializeField]
    private LayerMask mask;

    public void Starting(string IDs)
    {
        Player = GameObject.Find(IDs);
        Character = Player.transform.FindChild("Character" + IDs).gameObject;
        FirePoint = Character.transform.FindChild("AttackRange").gameObject;
        if (FirePoint == null)
        {
            Debug.LogWarning("ThunderArrow: No FirePoint found");
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Debug.Log("Ability 1 (Thunder Arrow): Ability Fired. Cooldown Started.");
            UseThunderArrow();
        }
    }

    [Client]
    void UseThunderArrow()
    {
        RaycastHit2D _Hit = Physics2D.Raycast(FirePoint.transform.position, FirePoint.transform.forward, Abilities.range, mask);
        if (Physics2D.Raycast(FirePoint.transform.position, FirePoint.transform.forward, Abilities.range, mask))
        {
            Debug.Log("Raycast was initiated");
            for (int i = 0; i < damagebleTags.Length; i++)
            {
                if (_Hit.collider.tag == damagebleTags[i])
                {
                    CmdPlayerdamage(_Hit.collider.name);
                }
            }

        }
    }

    [Command]
    void CmdPlayerdamage(string _ID)
    {
        if (SceneManager.GetActiveScene().name != "Multiplayer Arena")
        {
        }
            Debug.Log(_ID + " Has been Damaged");
    }
}
