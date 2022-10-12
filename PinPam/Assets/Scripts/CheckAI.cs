using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckAI : MonoBehaviour
{
    [SerializeField] AI ai;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Ball"))
        {
            ai.IsInside = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Ball"))
        {
            ai.IsInside = false;
        }
    }
}
