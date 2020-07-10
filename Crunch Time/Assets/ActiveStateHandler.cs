using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveStateHandler : MonoBehaviour
{

    public float myMinStoryState;
    public float myMaxStoryState;

    //public List<GameObjects> NPCs = new List<GameObjects>();

    public GameObject NPC;

    //public GameManager gameManager;

    void Update()
    {
        if (GameManager.storyState>= myMinStoryState && GameManager.storyState< myMaxStoryState)
        {
            NPC.SetActive(true);
        }
        else
            NPC.SetActive(false);
    }
}
