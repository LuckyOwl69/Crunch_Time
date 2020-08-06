using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//THIS SCRIPT SETS THE STORY STATE ONLY

public class GlobalEventController : MonoBehaviour
{
    //public float minStoryState;
    //public float maxStoryState;

    public float newStoryState;

    //public float storyState;

    //public GameManager gameManager;

    void Start()
    {
        //storyState = GameManager.storyState;
    }

    void OnTriggerStay2D(Collider2D other)
    {
        //if (Input.GetKey(KeyCode.E)) 
        //{
        //    if (GameManager.storyState >= minStoryState && GameManager.storyState < maxStoryState)
        //    {
        //        GameManager.storyState = newStoryState;
        //    }
        //}
        if (Input.GetKey(KeyCode.E) && GameManager.storyState < newStoryState) 
        {
            GameManager.storyState = newStoryState;

        }
    }
}
