using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player;

    public float eastBoundary, southBoundary, westBoundary, northBoundary;

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

        //eaast = 1.4, west -1.4, north 0.78, south -0.8
        
        if (player.position.x >= eastBoundary)
        {
            transform.position = new Vector3(eastBoundary, player.position.y, player.position.z + offset.z);

            if (player.position.y >= northBoundary)
            {
                transform.position = new Vector3(eastBoundary, northBoundary, player.position.z + offset.z);

            }

            if (player.position.y <= southBoundary)
            {
                transform.position = new Vector3(eastBoundary, southBoundary, player.position.z + offset.z);

            }
        }
        
        if (player.position.x <= westBoundary)
        {
            transform.position = new Vector3(westBoundary, player.position.y, player.position.z + offset.z);

            if (player.position.y >= northBoundary)
            {
                transform.position = new Vector3(westBoundary, northBoundary, player.position.z + offset.z);

            }

            if (player.position.y <= southBoundary)
            {
                transform.position = new Vector3(westBoundary, southBoundary, player.position.z + offset.z);

            }
        }
        
        if (player.position.x > westBoundary && player.position.x < eastBoundary)
        {
            transform.position = new Vector3(player.position.x, player.position.y, player.position.z + offset.z);

            if (player.position.y >= northBoundary)
            {
                transform.position = new Vector3(player.position.x, northBoundary, player.position.z + offset.z);

            }

            if (player.position.y <= southBoundary)
            {
                transform.position = new Vector3(player.position.x, southBoundary, player.position.z + offset.z);

            }
        }






        //if (player.position.x >= 1.4)
        //    transform.position = new Vector3(1.4, player.position.y, player.position.z + offset.z);



    }
}
