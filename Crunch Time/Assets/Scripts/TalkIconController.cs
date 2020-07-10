using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkIconController : MonoBehaviour
{
    public DialogueTrigger dialogueScript;

    public GameObject talkIcon;
    private bool _inTalkingRange = false;

    private void Start()
    {
        talkIcon.gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        talkIcon.gameObject.SetActive(true);
        _inTalkingRange = true;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        
        //if (Input.GetKeyUp(KeyCode.Return) || Input.GetKeyUp(KeyCode.E) || Input.GetKeyUp(KeyCode.Space))
        //{
        //    dialogueScript.TriggerDialogue();
            //Debug.Log("ass");
        //}
    }

    private void Update() {
        if (_inTalkingRange)
        {
          if (Input.GetKeyUp(KeyCode.E) || Input.GetKeyUp(KeyCode.Space))
          {
              dialogueScript.TriggerDialogue();
              //Debug.Log("ass");
          }
        }
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        talkIcon.gameObject.SetActive(false);
        _inTalkingRange = false;
    }
}
