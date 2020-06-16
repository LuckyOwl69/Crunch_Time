using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public Text currentSpeakerText;
    public Text dialogueText;

    private Queue<string> sentences;

    public Animator dialogueBoxAnimator;
    public Animator npcFaceAnimator;

    public List<GameObject> talkButtons;

    bool isTalking;


    void Start()
    {
        sentences = new Queue<string>();
        isTalking = false;
    }



    public void StartDialogue(Dialogue dialogue)
    {
        foreach (GameObject talkButton in talkButtons)
        {
            talkButton.gameObject.SetActive(false);
        }
        dialogueBoxAnimator.SetBool("IsOpen", true);
        npcFaceAnimator.SetBool("IsOpen", true);
        isTalking = true;

        currentSpeakerText.text = dialogue.name;

        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }


        DisplayNextSentence();


    }

    public void DisplayNextSentence()
    {
        if (isTalking)
        {
            if (sentences.Count == 0)
            {
                EndDialogue();
                return;
            }

            string sentence = sentences.Dequeue();
            StopAllCoroutines();
            StartCoroutine(TypeSentence(sentence));
        }

    }

    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }
    }

    void EndDialogue()
    {
        foreach (GameObject talkButton in talkButtons)
        {

        }
        dialogueBoxAnimator.SetBool("IsOpen", false);
        npcFaceAnimator.SetBool("IsOpen", false);
        isTalking = false;
    }
}
