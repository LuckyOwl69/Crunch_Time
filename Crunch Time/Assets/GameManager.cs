using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
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

    public Text questInformation;

    void Update()
    {
        UnityEngine.Debug.Log(storyState);
    }

    void Awake()
    {


        if (instance == null)
        {
            //set overworld positions
            overworldPos.x = overworldPosX;
            overworldPos.y = overworldPosY;

            instance = this;
            DontDestroyOnLoad(this.gameObject);

        }
        else
        {
            Destroy(this.gameObject);
        }


    }
}
