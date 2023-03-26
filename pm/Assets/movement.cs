using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rb2d;
    public bool grounded = true;
    public float jumpPower;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");


        rb2d.velocity = new Vector2(moveHorizontal * speed, moveVertical * 0f);

        if (Input.GetKeyDown("space") || Input.GetKeyDown("w") && grounded == true)
        {
            rb2d.AddForce(transform.up * jumpPower);
            grounded = false;
        }
    }
}
