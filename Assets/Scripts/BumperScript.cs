using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BumperScript : MonoBehaviour
{
    public float force = 20f;
    public int scoreValue = 100;
    public Vector3 scaleChange;

    private void OnCollisionEnter(Collision collision)
    {
        transform.localScale -= scaleChange;
        if (collision.gameObject.CompareTag("Ball"))
        {
            FindObjectOfType<GameController>().AddPoints(scoreValue);
            collision.gameObject.GetComponent<Rigidbody>().AddForce(force * Vector3.forward);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        transform.localScale += scaleChange;
    }
}
