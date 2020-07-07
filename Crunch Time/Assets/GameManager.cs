using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public static Vector3 overworldPos;

    public float overworldPosX;
    public float overworldPosY;

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
