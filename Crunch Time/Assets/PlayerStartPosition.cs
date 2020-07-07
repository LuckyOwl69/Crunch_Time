using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStartPosition : MonoBehaviour
{
    public GameObject player;
    public GameObject playerStartPos;

    // Start is called before the first frame update
    void Start()
    {
        player.transform.position = playerStartPos.transform.position;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
