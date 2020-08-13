using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//THIS SCRIPT SETS THE STORY STATE ONLY

public class GlobalEventController : MonoBehaviour
{
    public float newStoryState;

    void OnTriggerStay2D(Collider2D other)
    {
        if (Input.GetKey(KeyCode.E) && GameManager.storyState < newStoryState) 
        {
            GameManager.storyState = newStoryState;
            GameManager.hasNewQuest = true;
        }
    }
}
