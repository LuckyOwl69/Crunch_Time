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

    bool npcTalking = true;

    //public List<TalkIconController> NPCPrefabs;


    public GameObject talkButton;

    private bool _isTalking;


    void Start()
    {
        sentences = new Queue<string>();
        _isTalking = false;
        npcFace.SetBool("Idle", true);
        playerFace.SetBool("Idle", true);
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

        if (npcTalking)
            currentSpeakerText.text = dialogue.npcName;



        //set state of facial animation
        //dialogue.npcFace.SetBool("Idle", true);
        //dialogue.playerFace.SetBool("Idle", true);

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
            if (sentence.Contains("_npcTalking"))
            {
                npcFace.SetBool("Idle", false);
                playerFace.SetBool("Idle", true);
                sentence = sentence.Replace("_npcTalking", "");
                
            }
                
            else if (sentence.Contains("_playerTalking"))
            {
                npcFace.SetBool("Idle", true);
                playerFace.SetBool("Idle", false);
                sentence.Replace("_playerTalking", "");

            }



            StopAllCoroutines();
            StartCoroutine(TypeSentence(sentence));
        }

    }

    IEnumerator TypeSentence(string sentence)
    {
        if (sentence.Contains("_npcTalking"))
        {
            sentence.Replace("_npcTalking", "");

        }
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
