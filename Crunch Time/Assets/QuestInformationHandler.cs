using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestInformationHandler : MonoBehaviour
{
    public Animator questWindowAnimator;
    public Animator questWindowIconAnimator;

    public Animator mapWindowAnimator;
    public Animator mapWindowIconAnimator;


    //public bool hasNewQuest;

    public GameObject questWindowNotification;

    public GameObject questWindowBackground;



    void OpenQuestWindow()
    {
        questWindowAnimator.SetBool("IsOpen", true);
        questWindowIconAnimator.SetBool("IsOpen", true);
        questWindowBackground.gameObject.SetActive(true);
    }

    void CloseQuestWindow()
    {
        questWindowAnimator.SetBool("IsOpen", false);
        questWindowIconAnimator.SetBool("IsOpen", false);
        questWindowBackground.gameObject.SetActive(false);

    }

    void OpenMapWindow()
    {
        mapWindowAnimator.SetBool("IsOpen", true);
        mapWindowIconAnimator.SetBool("IsOpen", true);
        questWindowBackground.gameObject.SetActive(true);

    }

    void CloseMapWindow()
    {
        mapWindowAnimator.SetBool("IsOpen", false);
        mapWindowIconAnimator.SetBool("IsOpen", false);
        questWindowBackground.gameObject.SetActive(false);

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
        
        if (Input.GetKey(KeyCode.M))
        {
            OpenMapWindow();
        }

        if (Input.GetKeyUp(KeyCode.M))
        {
            CloseMapWindow();
        }



    }
}
