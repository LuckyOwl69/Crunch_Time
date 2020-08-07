using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;

public class QuestInformationChanger : MonoBehaviour
{
    public Text questName;
    public Text questInformation;

    public float storyState;

    public string newQuestName;
    public string newQuestInformation;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.storyState == storyState)
        {
            questName.text = newQuestName;
            questInformation.text = newQuestInformation;
        }
    }
}
