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

    public String playerName;
    public String npcName;


    //bool npcTalking = true;

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

        
        //currentSpeakerText.text = dialogue.npcName;


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

            //stuff that happens when npc talks
            if (sentence.Contains("_npcTalking"))
            {
                npcFace.SetBool("Idle", false);
                playerFace.SetBool("Idle", true);
                npcFaceAnimator.SetBool("IsOpen", true);


                currentSpeakerText.text = npcName;
                sentence = sentence.Replace("_npcTalking", "");
                
            }

            //stuff that happens when npc talks solo
            if (sentence.Contains("_npcSolo"))
            {
                playerFaceAnimator.SetBool("IsOpen", false);
                npcFace.SetBool("Idle", false);
                
                currentSpeakerText.text = npcName;
                sentence = sentence.Replace("_npcSolo", "");
                
            }

            //stuff that happens when player talks
            else if (sentence.Contains("_playerTalking"))
            {
                npcFace.SetBool("Idle", true);
                playerFace.SetBool("Idle", false);
                playerFaceAnimator.SetBool("IsOpen", true);


                currentSpeakerText.text = playerName;
                sentence = sentence.Replace("_playerTalking", "");

            }
            
            //stuff that happens when player talks solo
            else if (sentence.Contains("_playerSolo"))
            {
                npcFaceAnimator.SetBool("IsOpen", false);
                playerFace.SetBool("Idle", false);

                currentSpeakerText.text = playerName;
                sentence = sentence.Replace("_playerSolo", "");

            }

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
