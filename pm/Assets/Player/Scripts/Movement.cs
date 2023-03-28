using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] int jumpPower;
    [SerializeField] float fallMultiplier;
    public Transform groundCheck;
    public LayerMask groundLayer;
    bool isGrounded;
    Vector2 vecGravity;
    private Animator anim;
    private float movee;
    public float speed;

    void Start()
    {
        vecGravity = new Vector2(0, -Physics2D.gravity.y);
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    void flip()
    {
        if (rb.velocity.x < -0.01f) transform.eulerAngles = new Vector3(0, 180, 0);
        if (rb.velocity.x > 0.01f) transform.eulerAngles = new Vector3(0, 0, 0);
    }
    void Update()
    {
        movee = Input.GetAxis("Horizontal");

        rb.velocity = new Vector2(speed * movee, rb.velocity.y);

        flip();

        isGrounded = Physics2D.OverlapCapsule(groundCheck.position, new Vector2(1.4f, 0.37f), CapsuleDirection2D.Horizontal, 0, groundLayer);
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpPower);
        }
        if (rb.velocity.y < 0)
        {
            rb.velocity -= vecGravity * fallMultiplier * Time.deltaTime;
        }
        anim.SetBool(name: "IsInAir", value:!isGrounded);
        anim.SetBool(name: "Falling", value:!isGrounded && rb.velocity.y < 0);
        anim.SetBool(name: "IsWalking", value: movee != 0);
    }
}
