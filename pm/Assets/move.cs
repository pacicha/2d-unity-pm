using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    Vector2 movee;
    public int speed;

    void Start()
    {

    }
    void Update()
    {
        movee = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        transform.Translate(movee * speed * Time.deltaTime,Space.World);

        flip();
    }
    void flip()
    {
        if (movee.x < -0.01f) transform.localScale = new Vector3(-1, 1, 1);
        if (movee.x > 0.01f) transform.localScale = new Vector3(1, 1, 1);

    }
}
