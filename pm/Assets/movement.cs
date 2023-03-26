using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    public float speed;
    public float jump;

    private float Move;

    private Rigidbody2D rb2d;

    public bool isJumping;


    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Move = Input.GetAxis("Horizontal");

        rb2d.velocity = new Vector2(speed * Move, rb2d.velocity.y);

        if (Input.GetButtonDown("Jump") && isJumping == false)
        {
            rb2d.AddForce(new Vector2(rb2d.velocity.x, jump));
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Floor"))
        {
            isJumping = false;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Floor"))
        {
            isJumping = true;
        }
    }
}
