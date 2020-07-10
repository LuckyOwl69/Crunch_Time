using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//THIS SCRIPT SETS THE STORY STATE ONLY

public class GlobalEventController : MonoBehaviour
{
    public float minStoryState;
    public float maxStoryState;

    public float currentStoryState;

    public GameManager gameManager;

    void Update()
    {
        
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if (gameManager.storyState < maxStoryState && gameManager.storyState >= minStoryState) 
        {
            if (Input.GetKey(KeyCode.Return))
            {
                gameManager.storyState = currentStoryState;
            }
        }
            
    }
}
