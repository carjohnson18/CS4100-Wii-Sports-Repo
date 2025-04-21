using System;
using System.Collections;
using System.Collections.Generic;
using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.Rendering;

public class BatController : MonoBehaviour
{
    [SerializeField] private float powerMultiplier = 5f;
    [SerializeField] private float shotHeight = 7f;
    
    [SerializeField] Transform aimTarget;
    [SerializeField] Rigidbody ballrb;
    [SerializeField] Rigidbody batRb;
    //[SerializeField] private Transform serveRight;
    //[SerializeField] private Transform serveLeftR;
    //public XROrigin xrOrigin;

    void Start()
    {
        GameObject ball = GameObject.FindGameObjectWithTag("Ball");
        ballrb = ball.GetComponent<Rigidbody>();
    }

    public void Reset()
    {
        //transform.position = serveRight.position;
    }

    
    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Ball")) return;
        Vector3 direction = (aimTarget.position - transform.position);
        //other.GetComponent<Rigidbody>().velocity = direction.normalized * powerMultiplier + new Vector3(0, shotHeight, 0);
        ballrb.useGravity = true;
        ballrb.AddForce(direction.normalized * powerMultiplier + new Vector3(0, shotHeight, 0), ForceMode.Impulse);
        ballrb.GetComponent<BallPhysics>().hitter = "player";
        //Vector3 direction = (aimTarget.position - transform.position);
        //batRb.isKinematic = true;
        //Vector3 velocity = direction.normalized * powerMultiplier + new Vector3(0f, shotHeight, 0f);

        //BallMotion ballMotion = other.GetComponent<BallMotion>();
        //ballMotion.HitBall(velocity);
        
    }
    
}