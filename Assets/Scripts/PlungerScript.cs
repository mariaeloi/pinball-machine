using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlungerScript : MonoBehaviour
{
    public Slider powerSlider;
    public float maxPower = 100f;

    private float power;
    private float minPower = 0f;
    private List<Rigidbody> ballList;
    private bool ballReady;

    void Start()
    {
        ballList = new List<Rigidbody>();

        powerSlider.minValue = minPower;
        powerSlider.maxValue = maxPower;
    }
    
    void Update()
    {
        if (ballReady)
        {
            powerSlider.gameObject.SetActive(true);
        }
        else
        {
            powerSlider.gameObject.SetActive(false);
        }
        
        if(ballList.Count > 0)
        {
            ballReady = true;
            if (Input.GetKey(KeyCode.Space))
            {
                if(power < maxPower)
                {
                    power += 50 * Time.deltaTime;
                    powerSlider.value = power;
                }
            }
            if (Input.GetKeyUp(KeyCode.Space))
            {
                foreach (Rigidbody r in ballList)
                {
                    r.AddForce(power * Vector3.forward);
                }
            }
        }
        else
        {
            ballReady = false;
            power = 0f;
            powerSlider.value = power;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            ballList.Add(other.gameObject.GetComponent<Rigidbody>());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            ballList.Remove(other.gameObject.GetComponent<Rigidbody>());
        }
    }
}
