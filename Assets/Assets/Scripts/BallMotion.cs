using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMotion : MonoBehaviour
{
    [SerializeField] private Vector3 initalVelocity;
    [SerializeField] private float decayDuration = 1f;
    [SerializeField] private float minSpeed = 1f;
    [SerializeField] private float timer = 0f;
    [SerializeField] private bool isMoving = false;
    [SerializeField] private float decaySpeed = 1f;
    private Rigidbody ballRb;
    
    void Start()
    {
        ballRb = GetComponent<Rigidbody>();
    }
    
    void FixedUpdate()
    {
        if (!isMoving) return;
        timer += Time.deltaTime;
        float t = timer / decayDuration;
        float verticalVelocity = ballRb.velocity.y;
        float decayFactor = Mathf.Exp(-decaySpeed * t);
        float rawSpeed = initalVelocity.magnitude * decayFactor;
        float speed = Mathf.Max(minSpeed, rawSpeed, decayFactor);
        if (timer <= decayDuration)
        {
            Vector3 horizontal = new Vector3(initalVelocity.x, 0f, initalVelocity.z).normalized * speed;
            ballRb.velocity = new Vector3(horizontal.x, verticalVelocity, horizontal.z);
        }
    }
    
    public void HitBall(Vector3 velocity)
    {
        initalVelocity = velocity;
        timer = 0f;
        isMoving = true;
    }
}
