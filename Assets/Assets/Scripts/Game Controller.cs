using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameState initalState;

    public GameObject ball;

    public Rigidbody ballrb;
    
    // Start is called before the first frame update
    void Start()
    {
        ballrb = ball.GetComponent<Rigidbody>();
        SaveInitalGameState();

    }

    void SaveInitalGameState()
    {
     
   

    }

    public class GameState
    {
    }
}
