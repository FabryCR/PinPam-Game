using System.Collections;
using UnityEngine;

public class AvoidJumping : MonoBehaviour
{

    [SerializeField] Ball ball;

    public static bool InArea = false;
    public static float timer = -2f;

    void Update()
    {
        timer += Time.deltaTime;

        if (InArea == true && timer > 5)
        {
            InArea = false;
            ball.ResetWithCount();
            FindObjectOfType<AudioManager>().Play("Out");
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Ball"))
        {
            InArea = !InArea;
            timer = -1f;
        }
    }
}
