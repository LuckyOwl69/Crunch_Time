using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ExitController : MonoBehaviour
{
    public string NextScene;

    public GameManager GameManagerObject;

    public float NextScenePositionX;
    public float NextScenePositionY;

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if(Input.GetKeyUp(KeyCode.E))
                {
                SceneManager.LoadScene(NextScene);
                //SceneManager.LoadScene('"' + NextScene.name + '"');

                GameManager.overworldPos.x = NextScenePositionX;
                GameManager.overworldPos.y = NextScenePositionY;

                //GameManager.storyState = currentStoryState;
                }

        }
    }
}
