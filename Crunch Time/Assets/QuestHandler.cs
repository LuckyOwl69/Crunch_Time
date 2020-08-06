using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestHandler : MonoBehaviour
{
    public Text questName;
    public Text questDescription;

    float currentStoryState;

    public GameManager gameManager;
    //public GameObject manager;


    // Update is called once per frame
    void FixedUpdate()
    {
        //currentStoryState = GameManager.storyState;

        //if (currentStoryState == 1)
        //{
        //    questName.text = "Talk to Burger Boss";
        //    questDescription.text = "Go speak to Burger Boss, he's right in front of you!";
        //}

        //if (currentStoryState == 1.01) 
        //{
        //    questName.text = "Get some Coffee for Burger Boss";
        //    questDescription.text = "Go to the lunchroom (south east) and get some coffee from the coffee machine.";
        //}

        //if (currentStoryState == 1.1)
        //{
        //    questName.text = "Find some coffee on level 2";
        //    questDescription.text = "The coffee machine in the lunchroom is busted. Use the elevator to go to level 2 and find another.";
        //}

        //if (currentStoryState == 1.2)
        //{
        //    questName.text = "Bring Burger Boss some coffee";
        //    questDescription.text = "You finally found some coffee! Bring it back to your boss.";
        //}

        //if (currentStoryState == 1.3)
        //{
        //    questName.text = "Vertical slice complete!";
        //    questDescription.text = "Well thats it. Feel free to explore.";
        //}
    }
}
