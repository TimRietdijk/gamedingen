using UnityEngine;
using System.Collections;

public class CameraControler : MonoBehaviour {

    public GameObject Target;
    public float Speed;
    public float hight;
    public GameObject Player;

    private Vector3 TargetPosition;

    void Start() {
    }

    public void SetCamera(string _IDs)
    {
        Player = GameObject.Find(_IDs);
        if (Target == null)
        {
            Player = GameObject.Find(_IDs);
            Target = Player.transform.FindChild("Character" + _IDs).gameObject;
            return;
        }
    }

    void Update () {

        TargetPosition = new Vector3(Target.transform.position.x, Target.transform.position.y, hight);
        transform.position = Vector3.Lerp(transform.position, TargetPosition, Speed * Time.deltaTime);            
	}
}
