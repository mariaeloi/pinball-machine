using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetScript : MonoBehaviour
{
    public int scoreValue = 150;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            FindObjectOfType<GameController>().AddPoints(scoreValue);
        }
    }
}
