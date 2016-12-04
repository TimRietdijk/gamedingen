using UnityEngine;
using System.Collections;

public class CameraControler : MonoBehaviour {

    public GameObject Target;
    public float Speed;

    private Vector3 TargetPosition;

    void Update () {
        TargetPosition = new Vector3(Target.transform.position.x, Target.transform.position.y, -6.5f);
        transform.position = Vector3.Lerp(transform.position, TargetPosition, Speed * Time.deltaTime);            
	}
}
