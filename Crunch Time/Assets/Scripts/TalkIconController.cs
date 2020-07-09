using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkIconController : MonoBehaviour
{
    public DialogueTrigger dialogueScript;

    public GameObject talkIcon;


    private void Start()
    {
        
        talkIcon.gameObject.SetActive(false);
        

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        talkIcon.gameObject.SetActive(true);
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetKey(KeyCode.Return) || Input.GetKey(KeyCode.E) || Input.GetKey(KeyCode.Space))
        {
            dialogueScript.TriggerDialogue();
            //Debug.Log("ass");
        }
    }



    private void OnTriggerExit2D(Collider2D collision)
    {
        
        talkIcon.gameObject.SetActive(false);
        
    }
}
