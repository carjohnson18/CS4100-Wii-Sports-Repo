using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BallPhysics : MonoBehaviour
{
    private Rigidbody ballRb;
    private Vector3 initalPos;
    public string hitter;
    [SerializeField] private int playerScore;
    [SerializeField] private int botScore;
    [SerializeField] private int inlinehit;
    [SerializeField] private float maxSpeed;
    [SerializeField] TextMeshProUGUI playerScoreText;
    [SerializeField] TextMeshProUGUI botScoreText;
    // Start is called before the first frame update
    void Start()
    {
        ballRb = GetComponent<Rigidbody>();
        ballRb.useGravity = false;
        initalPos = transform.position;
    }

    private void FixedUpdate()
    { 
        ballRb.velocity = Vector3.ClampMagnitude(ballRb.velocity, maxSpeed);
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Racquet"))
        {
            inlinehit = 0;
        }
        if (collision.gameObject.CompareTag("Wall"))
        {
            ballRb.velocity = Vector3.zero;
            ballRb.angularVelocity = Vector3.zero;
            transform.position = initalPos;
            ballRb.useGravity = false;
            
            if (hitter == "bot" && inlinehit == 0)
            {
                playerScore++;
                updateScore();
            }

            if (hitter == "player" && inlinehit == 0)
            {
                botScore++;
                updateScore();
            }

            if (hitter == "bot" && inlinehit == 1)
            {
                botScore++;
                updateScore();
            }

            if (hitter == "player" && inlinehit == 1)
            {
                playerScore++;
                updateScore();
            }
        }
        if (collision.gameObject.CompareTag("Net"))
        {
            if (hitter == "bot")
            {
                playerScore++;
                ballRb.velocity = Vector3.zero;
                ballRb.angularVelocity = Vector3.zero;
                transform.position = initalPos;
                ballRb.useGravity = false;
                updateScore();
            }

            if (hitter == "player")
            {
                botScore++;
                ballRb.velocity = Vector3.zero;
                ballRb.angularVelocity = Vector3.zero;
                transform.position = initalPos;
                ballRb.useGravity = false;
                updateScore();
            }
        }


    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Racquet"))
        {
            inlinehit = 0;
        }
        if (other.gameObject.CompareTag("InLine"))
        {
            inlinehit++;
        }

        if (other.gameObject.CompareTag("Bot"))
        {
            inlinehit = 0;
        }
        
        if (other.gameObject.CompareTag("OutLine") && inlinehit == 0)
        {
            if (hitter == "player")
            {
                botScore++;
                ballRb.velocity = Vector3.zero;
                ballRb.angularVelocity = Vector3.zero;
                transform.position = initalPos;
                ballRb.useGravity = false;
                updateScore();
            }
            else if (hitter == "bot")
            {
                playerScore++;
                ballRb.velocity = Vector3.zero;
                ballRb.angularVelocity = Vector3.zero;
                transform.position = initalPos;
                ballRb.useGravity = false;
                updateScore();
            }
        }

        if (inlinehit == 2)
        {
            if (hitter == "player")
            {
                playerScore++;
                ballRb.velocity = Vector3.zero;
                ballRb.angularVelocity = Vector3.zero;
                transform.position = initalPos;
                ballRb.useGravity = false;
                updateScore();
            }
            else if (hitter == "bot")
            {
                botScore++;
                ballRb.velocity = Vector3.zero;
                ballRb.angularVelocity = Vector3.zero;
                transform.position = initalPos;
                ballRb.useGravity = false;
                updateScore();
            }
        }
        
    }

    void updateScore()
    {
        playerScoreText.text = "Player: " + playerScore;
        botScoreText.text = "Bot: " + botScore;
    }
}
