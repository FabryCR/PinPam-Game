using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    Rigidbody2D rb;
    float randomNumX;
    float randomNumY;
    float X;
    float Y;
    [SerializeField] float speed;
    Vector2 startPos;
    Vector2 play1Pos;
    Vector2 play2Pos;
    GameMNG GameMNG;

    //AvoidJumping avdJmp;
    [SerializeField] Transform player1;
    [SerializeField] Transform player2;

    void Start()
    {
        //avdJmp = GetComponent<AvoidJumping>();

        play1Pos = player1.transform.position;
        play2Pos = player2.transform.position;

        GameMNG = FindObjectOfType<GameMNG>();

        startPos = transform.position;
        rb = this.GetComponent<Rigidbody2D>();
        StartCoroutine(FirstLaunch());
    }

    void Launch()
    {

        randomNumX = Random.Range(0, 2);
        randomNumY = Random.Range(0, 2);

        switch (randomNumX)
        {
            case 0:
                X = -1f;
                break;
            case 1:
                X = 1f;
                break;
        }

        switch (randomNumY)
        {
            case 0:
                Y = -0.5f;
                break;
            case 1:
                Y = 0.5f;
                break;
        }


        rb.AddForce(new Vector2(X * speed, Y * speed));
        //avdJmp.StartTimer();
    }

    public void Reset()
    {
        AvoidJumping.timer = -1f;
        AvoidJumping.InArea = false;


        player1.transform.position = play1Pos;
        player2.transform.position = play2Pos;
        transform.position = startPos;
        rb.velocity = Vector2.zero;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("RightCollider"))
        {
            FindObjectOfType<AudioManager>().Play("Score");
            //Punto para el de la izq.
            GameMNG.UpdateScore(1);
            ResetWithCount();

        }
        else if (other.CompareTag("LeftCollider"))
        {
            FindObjectOfType<AudioManager>().Play("Score");
            //Punto para el de la der.
            GameMNG.UpdateScore(2);
            ResetWithCount();
        }
    }
    
    public void ResetWithCount()
    {
        StartCoroutine(waitForLaunch());
    }

    IEnumerator waitForLaunch()
    {
        Reset();
        yield return new WaitForSeconds(1f);
        Launch();
    }

    IEnumerator FirstLaunch()
    {
        yield return new WaitForSeconds(2f);
        Launch();
    }

}
