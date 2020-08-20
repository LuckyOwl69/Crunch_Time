using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestMenuItemController : MonoBehaviour
{
    public GameObject itemGrey;
    public GameObject item;

    public float storyState;
    // Start is called before the first frame update
    void Start()
    {
        itemGrey.SetActive(true);
        item.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.storyState> storyState)
        {
            itemGrey.SetActive(false);
            item.SetActive(true);
        }

    }
}
