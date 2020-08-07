using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestInformationHandler : MonoBehaviour
{
    public Animator questWindowAnimator;

    
    //public bool hasNewQuest;

    public GameObject questWindowNotification;



    void OpenQuestWindow()
    {
        questWindowAnimator.SetBool("IsOpen", true);
    }
    
    void CloseQuestWindow()
    {
        questWindowAnimator.SetBool("IsOpen", false);
    }




    void Update()
    {
        if (GameManager.hasNewQuest == true)
        {
            questWindowNotification.gameObject.SetActive(true);
        }

        if (Input.GetKey(KeyCode.Q))
        {
            OpenQuestWindow();
            GameManager.hasNewQuest = false;
            questWindowNotification.gameObject.SetActive(false);


        }

        if (Input.GetKeyUp(KeyCode.Q))
        {
            CloseQuestWindow();
        }

    }
}
