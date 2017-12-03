using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pancakeLogic : MonoBehaviour {
    public gameLogic GL;
    public float limit = -97f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (transform.position.y < limit) {
            GL.endGame();
            Destroy(gameObject);
        }
	}
}
