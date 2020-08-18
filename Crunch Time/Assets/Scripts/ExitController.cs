using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ExitController : MonoBehaviour
{
    public string NextScene;

    //public GameManager GameManagerObject;
    public GameObject useIndicator;

    public Animator transitionAnimation;
    //public Animator doorAnimation;

    public float NextScenePositionX;
    public float NextScenePositionY;

    void Start()
    {
        useIndicator.SetActive(false);

    }

    //while player is standing inside collier
    void OnTriggerStay2D(Collider2D other)
    {
        //checking if player is inside collider
        if (other.gameObject.CompareTag("Player"))
        {
            //when player presses E inside door collider
            if (Input.GetKey(KeyCode.E))
            {
                StartCoroutine(LoadNewScene());
                

            }

        }
    }

    

    IEnumerator LoadNewScene()
    {
        //run end animation
        transitionAnimation.SetTrigger("end");

        //wait while animation is running
        yield return new WaitForSeconds(1.5f);

        //scene to be loaded
        SceneManager.LoadScene(NextScene);

        //player location in world on transition
        GameManager.overworldPos.x = NextScenePositionX;
        GameManager.overworldPos.y = NextScenePositionY;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        useIndicator.SetActive(true);
        //doorAnimation.SetBool("Open", true);

    }
    void OnTriggerExit2D(Collider2D other)
    {
        useIndicator.SetActive(false);
        //doorAnimation.SetBool("Open", false);


    }
}
