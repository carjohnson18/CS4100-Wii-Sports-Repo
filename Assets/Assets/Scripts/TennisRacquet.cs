using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TennisRacquet : MonoBehaviour
{

    public float powerMultiply = 5f;

    public float minPower = 5f;

    public float maxPower = 20f;
    public Rigidbody racquetRb;
    // Start is called before the first frame update
    void Start()
    {
        racquetRb = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            Rigidbody ballRb = collision.gameObject.GetComponent<Rigidbody>();

            if (ballRb != null)
            {
                Vector3 racquetVelocity = racquetRb.velocity;

                if (racquetVelocity.magnitude > 0.1f)
                {
                    Vector3 hitDirection = racquetVelocity.normalized;
                    
                    float power = Mathf.Clamp(racquetVelocity.magnitude * powerMultiply, minPower, maxPower);
                    
                    ballRb.velocity = hitDirection * power;
                }
            }
        }
    }
}
