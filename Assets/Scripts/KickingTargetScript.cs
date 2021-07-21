using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KickingTargetScript : MonoBehaviour
{
    public float force = 50f;
    public int scoreValue = 50;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            FindObjectOfType<GameController>().AddPoints(scoreValue);
            other.gameObject.GetComponent<Rigidbody>().AddForce(force * Vector3.forward);
        }
    }
}
