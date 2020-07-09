using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalEventController : MonoBehaviour
{
    public float minStoryState;
    public float maxStoryState;

    public float currentStoryState;

    public GameManager gameManager;

    void Update()
    {
        //GameManager.storyState = currentStoryState;


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
