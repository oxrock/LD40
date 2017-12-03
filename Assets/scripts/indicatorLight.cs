using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class indicatorLight : MonoBehaviour {

    SpriteRenderer sr;
    public Color32 begining;
    public Color32 end;
    float t = 0f;
    float limit = 2f;
    

    public void reset(Vector2 newPos,float timeAmount) {
        transform.position = newPos;
        limit = timeAmount;
        t = 0f;
    }

    void Start () {
        sr = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
        t += Time.deltaTime;
        sr.color = Color32.Lerp(begining, end, t / limit);
	}
}
