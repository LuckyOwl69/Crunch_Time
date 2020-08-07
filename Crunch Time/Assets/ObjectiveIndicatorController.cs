using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectiveIndicatorController : MonoBehaviour
{
    public GameObject objectiveIndicator;
    public float storyState;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (storyState == GameManager.storyState)
        {
            objectiveIndicator.SetActive(true);
        }
        else
            objectiveIndicator.SetActive(false);

    }
}
