using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class start : MonoBehaviour {

	public void StartGame (string sceneToChangeTo) {
        SceneManager.LoadScene(sceneToChangeTo);
	
	}
}
