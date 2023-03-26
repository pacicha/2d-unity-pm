using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    Vector2 moved;
    public int speed;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        moved = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        transform.Translate(moved * speed * Time.deltaTime,Space.World);

        flip();
    }
    void flip()
    {
        if (moved.x < 0.01f) transform.localScale = new Vector3(-1, 1, 1);
        if (moved.x > 0.01f) transform.localScale = new Vector3(1, 1, 1);

    }
}