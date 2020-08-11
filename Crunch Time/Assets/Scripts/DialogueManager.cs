using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Permissions;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class DialogueManager : MonoBehaviour
{
    public Text currentSpeakerText;
    public Text dialogueText;

    private Queue<string> sentences;

    public Animator dialogueBoxAnimator;
    public Animator npcFaceAnimator;
    public Animator playerFaceAnimator;

    public Animator npcFace;
    public Animator playerFace;

    //public List<TalkIconController> NPCPrefabs;


    public GameObject talkButton;

    private bool _isTalking;


    void Start()
    {
        sentences = new Queue<string>();
        _isTalking = false;
    }

    // public but unsettable IsTalking variable lets others know
    // if we're already busy.
    public bool IsTalking
    {
        get { return _isTalking; }
    }

    void Update()
    {
      // Only listen for next-bit-of-dialogue key if we're in conversation
      if (_isTalking)
      {
        if (Input.GetKeyUp(KeyCode.Space)) 
        {
          DisplayNextSentence();
        }
      }
    }

    public void StartDialogue(Dialogue dialogue)
    {
        talkButton.gameObject.SetActive(false);

        FaceAnimationsStart();

        _isTalking = true;

        currentSpeakerText.text = dialogue.npcName;

        //set state of facial animation
        dialogue.npcFace.SetBool("Idle", false);
        dialogue.playerFace.SetBool("Idle", true);

        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }


        DisplayNextSentence();

    }

    public void DisplayNextSentence()
    {
        if (_isTalking)
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
        talkButton.gameObject.SetActive(true);


        FaceAnimationsEnd();

        _isTalking = false;
    }

    void FaceAnimationsStart()
    {
        dialogueBoxAnimator.SetBool("IsOpen", true);
        npcFaceAnimator.SetBool("IsOpen", true);
        playerFaceAnimator.SetBool("IsOpen", true);
        //npcFace.SetBool("Idle", true);
        //playerFace.SetBool("Idle", true);
    }
    
    void FaceAnimationsEnd()
    {
        dialogueBoxAnimator.SetBool("IsOpen", false);
        npcFaceAnimator.SetBool("IsOpen", false);
        playerFaceAnimator.SetBool("IsOpen", false);
    }
}
