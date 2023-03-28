using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    private float movee;
    public float speed;
    public Rigidbody2D rb;

    void Start()
    {

    }
    void Update()
    {
        movee = Input.GetAxis("Horizontal");

        rb.velocity = new Vector2(speed * movee, rb.velocity.y);

        flip();
    }
    void flip()
    {
        if (rb.velocity.x < -0.01f) transform.localScale = new Vector3(-0.5f, 0.5f, 0.5f);
        if (rb.velocity.x > 0.01f) transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
    }
}
