using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player;

    //float xPos, yPos, zPos;


    //float xPos = playerPrefab.transform.position.x;
    //float yPos = player.transform.position.y;

    public Vector3 offset;
    //public float offset2;
    // Start is called before the first frame update
    void Start()
    {//
        
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position.x = player.position.x;
        //transform.position.y = player.position.y;
        transform.position = player.position + offset;

        //if (player.position.x >= 1.4f)
        //    transform.position = new Vector3( 1.4f, player.position.y, player.position.z+offset.z);
        //if (player.position.x <= -1.4f)
        //    transform.position = new Vector3( -1.4f, player.position.y, player.position.z+offset.z);
        
        //if (player.position.y <= -0.8f)
        //{
        //    transform.position = new Vector3(player.position.x, -0.8f, player.position.z + offset.z);

        //    if (player.position.x >= 1.4f)
        //    {
        //        transform.position = new Vector3(1.4f, -0.8f, player.position.z + offset.z);

        //    }
        //}
        
        if (player.position.x >= 1.4f)
        {
            transform.position = new Vector3(1.4f, player.position.y, player.position.z + offset.z);

            if (player.position.y >= 0.78f)
            {
                transform.position = new Vector3(1.4f, 0.78f, player.position.z + offset.z);

            }

            if (player.position.y <= -0.8f)
            {
                transform.position = new Vector3(1.4f, -0.8f, player.position.z + offset.z);

            }
        }
        
        if (player.position.x <= -1.4f)
        {
            transform.position = new Vector3(-1.4f, player.position.y, player.position.z + offset.z);

            if (player.position.y >= 0.78f)
            {
                transform.position = new Vector3(-1.4f, 0.78f, player.position.z + offset.z);

            }

            if (player.position.y <= -0.8f)
            {
                transform.position = new Vector3(-1.4f, -0.8f, player.position.z + offset.z);

            }
        }
        
        if (player.position.x > -1.4f && player.position.x < 1.4f)
        {
            transform.position = new Vector3(player.position.x, player.position.y, player.position.z + offset.z);

            if (player.position.y >= 0.78f)
            {
                transform.position = new Vector3(player.position.x, 0.78f, player.position.z + offset.z);

            }

            if (player.position.y <= -0.8f)
            {
                transform.position = new Vector3(player.position.x, -0.8f, player.position.z + offset.z);

            }
        }






        //if (player.position.x >= 1.4)
        //    transform.position = new Vector3(1.4, player.position.y, player.position.z + offset.z);



    }
}
