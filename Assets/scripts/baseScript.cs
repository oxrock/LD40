using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class baseScript : MonoBehaviour
{
    Rigidbody2D rb;
    public float force = 5f;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();        
    }

    void FixedUpdate() {
        if (Input.GetButton("left")) {
            rb.AddForce(Vector2.left * (force * Time.fixedDeltaTime));
            //print("left");
        }
        if (Input.GetButton("right"))
        {
            rb.AddForce(Vector2.right * (force * Time.fixedDeltaTime));
            //print("right");
        }
    }
}
