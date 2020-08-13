using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    //new one
    public static GameManager instance;

    public static Vector3 overworldPos;

    public float overworldPosX;
    public float overworldPosY;

    public static float storyState;

    public float tempStoryState;

    public static bool hasNewQuest;

    void Update()
    {
        Debug.Log(storyState);
        if (tempStoryState != 0)
            storyState = tempStoryState;
    }

    void Awake()
    {


        if (instance == null)
        {
            //set overworld positions
            overworldPos.x = overworldPosX;
            overworldPos.y = overworldPosY;

            //hasNewQuest = hasNewQuest;

            instance = this;
            DontDestroyOnLoad(this.gameObject);

        }
        else
        {
            Destroy(this.gameObject);
        }


    }
}
