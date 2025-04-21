using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetButton : MonoBehaviour
{
    // Start is called before the first frame update
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnButtonClick()
    {
        Debug.Log("Reset button clicked");
        ResetToMainScene();
        
    }

    public void ResetToMainScene()
    {
        SceneManager.LoadScene("Main");
    }
}
