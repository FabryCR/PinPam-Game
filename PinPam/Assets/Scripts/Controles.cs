using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controles : MonoBehaviour
{
    Rigidbody2D rb;
    Vector2 direction;
    [SerializeField] bool useWASD;
    [SerializeField] float speed;

    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (useWASD)
        {
            direction = new Vector2(0, Input.GetAxis("Vertical1"));
        }
        else
        {
            direction = new Vector2(0, Input.GetAxis("Vertical2"));
        }
    }

    private void FixedUpdate()
    {
        movePlayers(direction);
    }

    private void movePlayers(Vector2 direc)
    {
        rb.velocity = direc * speed * Time.deltaTime;
    }
}
