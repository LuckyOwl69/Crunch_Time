using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using System.Collections.List;

public class DialogueTrigger : MonoBehaviour
{
    //public Dialogue dialogue;
    public List<Dialogue> dialogues;
    protected int currentDialogue;

    private void Start()
    {

    }

    public void TriggerDialogue()
    {
        //Debug.Log("TriggerDialogue, currentDialogue = " + currentDialogue);

        // If dialoguemanager isn't already mid conversation, pass some dialogue to it,
        // and increment to the next one (if we aren't at end of list)
        if ( FindObjectOfType<DialogueManager>().IsTalking == false)
        {
          FindObjectOfType<DialogueManager>().StartDialogue(dialogues[currentDialogue]);
          // Wait for dialogue to be complete (dialoguemanager closes dialogue)
          if (currentDialogue < dialogues.Count-1) currentDialogue++;   // Count up if we aren't at end of list.
        }
    }
}
