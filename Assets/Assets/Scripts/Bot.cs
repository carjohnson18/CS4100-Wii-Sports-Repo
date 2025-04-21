using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bot : MonoBehaviour
{
    [SerializeField] private float speed = 10;
    [SerializeField] private float powerMultiplier = 9f;
    [SerializeField] private float shotHeight =5f;
    [SerializeField] Transform ball;
    public Transform[] aimTargets;
    private Transform AimTargetBot;
    private Vector3 target;
    void Start()
    {
        target = transform.position;
    }

    void PickRandom()
    {
        int randomIndex = Random.Range(0, aimTargets.Length);
        AimTargetBot = aimTargets[randomIndex];
    }

    void Update()
    {
        MoveToBall();
    }
    void MoveToBall()
    {
        target.x = ball.position.x;
        transform.position = Vector3.MoveTowards(transform.position, target, speed);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (! other.CompareTag("Ball")) return;
        
        //Debug.Log("collided");
        PickRandom();
        Vector3 direction = (AimTargetBot.position - transform.position);
        other.GetComponent<Rigidbody>().velocity = direction.normalized * powerMultiplier + new Vector3(0, shotHeight, 0);
        ball.GetComponent<BallPhysics>().hitter = "bot";
    }
}
