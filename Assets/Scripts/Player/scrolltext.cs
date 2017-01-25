using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class scrolltext : MonoBehaviour {

    private float speed;
    private Vector3 direction;
    private float fadetime;

	void Update () {
        float translation = speed * Time.deltaTime;

        transform.Translate(direction * translation);
	}

    public void Initialize(float speed, Vector3 direction, float fadetime)
    {
        this.speed = speed;
        this.direction = direction;
        this.fadetime = fadetime;

        StartCoroutine(FadeOut());
    }

    public IEnumerator FadeOut()
    {
        float startingalpha = GetComponent<Text>().color.a;
        float rate = 1.0f / fadetime;
        float progress = 0.0f;

        while (progress < 1.0)
        {
            Color tmpColor = GetComponent<Text>().color;

            GetComponent<Text>().color = new Color(tmpColor.r, tmpColor.g, tmpColor.b, Mathf.Lerp(startingalpha, 0, progress));
            progress += rate * Time.deltaTime;

            yield return null;
        }
        Destroy(gameObject);

    }

}
