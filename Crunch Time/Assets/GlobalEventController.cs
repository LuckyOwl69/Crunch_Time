using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//THIS SCRIPT SETS THE STORY STATE ONLY

public class GlobalEventController : MonoBehaviour
{
    public float minStoryState;
    public float maxStoryState;

    public float newStoryState;

    //public GameManager gameManager;

    void OnTriggerStay2D(Collider2D collision)
    {
        if (GameManager.storyState < maxStoryState && GameManager.storyState >= minStoryState) 
        {
            GameManager.storyState = newStoryState;
        }
            
    }
}
