using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestInformationHandler : MonoBehaviour
{
    public Animator questWindowAnimator;




    void OpenQuestWindow()
    {
        questWindowAnimator.SetBool("IsOpen", true);
    }
    
    void CloseQuestWindow()
    {
        questWindowAnimator.SetBool("IsOpen", false);
    }

    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            OpenQuestWindow();
        }
        
        if (Input.GetKeyUp(KeyCode.Q))
        {
            CloseQuestWindow();
        }

    }
}
