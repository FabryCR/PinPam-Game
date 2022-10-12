using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour
{
    Rigidbody2D rb;
    [HideInInspector] public Vector2 AI_Direction;
    [SerializeField] float speed;

    [HideInInspector] public bool IsInside;

    //
    Transform CanonArma;
    [SerializeField] Transform ball;
    float ballDirec;
    [HideInInspector] public Vector2 startPos;

    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        AI_Direction = new Vector2(0, 0);
        IsInside = false;
        startPos = transform.position;
    }

    void Update()
    {
        //if (IsInside)
        //{
        //    ballDirec = ball.position.y;
        //    AI_Direction = new Vector2(0, ballDirec);
        //}
        //else
        //{
        //    //speed -= 100f;
        //    AI_Direction = startPos;
        //}

        if (IsInside)
        {
            if (transform.position.y > ball.position.y)
            {
                AI_Direction.y = -1f;
            }
            else
            {
                AI_Direction.y = 1f;
            }
        }
    }

    void FixedUpdate()
    {
        //Moverse cuando la detecte
        rb.velocity = AI_Direction * speed * Time.fixedDeltaTime;
        AI_Direction.y = 0f;
    }
}



//RaycastHit2D hitInfo = Physics2D.Raycast(CanonArma.position, CanonArma.right, LayerMask.NameToLayer("Enemigo"));

//if (hitInfo.collider != null)
//{
//    if (hitInfo.collider.CompareTag("Boss1"))
//    {
//        Debug.Log("HIT");
//    }
//    else
//    {
//        Debug.Log("NOTHIT");
//    }
//}