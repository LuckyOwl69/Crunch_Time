using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class BattleTrigger : MonoBehaviour
{
    public GameObject player;

    public float battleTrigger;

    public float distanceTravelled;

    public Vector2 playerPositionPrevious;
    //public Vector2 playerPositionCurrent;

    public bool inRoomWithBattles;

    public string battleScene;


    // Start is called before the first frame update
    void Start()
    {
        battleTrigger = Random.Range(10.0f, 20.0f);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void DistanceCalculator()
    {
        float dist = Vector3.Distance(player.transform.position, playerPositionPrevious);

        distanceTravelled += dist;

        if (inRoomWithBattles == true)
        {
            if (distanceTravelled >= battleTrigger)
            {
                //GameManager.overworldPos = transform.position;
                SceneManager.LoadScene(battleScene);

            }
        }


        playerPositionPrevious = player.transform.position;


    }

    void FixedUpdate()
    {

        DistanceCalculator();
    }
}
