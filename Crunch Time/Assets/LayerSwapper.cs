using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayerSwapper : MonoBehaviour
{
    public GameObject thisObjectsParent;
    public GameObject playerObject;

    public SpriteRenderer thisSprite;
    public SpriteRenderer playerSprite;

    public float offset;
    public int layerOffset;

    // Start is called before the first frame update
    void Start()
    {
        thisSprite = GetComponent<SpriteRenderer>();
        playerSprite = playerObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (thisObjectsParent.transform.position.y + offset <= playerObject.transform.position.y)
        {
            thisSprite.sortingOrder = playerSprite.sortingOrder + 1 + layerOffset;
        }
        else if (thisObjectsParent.transform.position.y + offset > playerObject.transform.position.y)
        {
            thisSprite.sortingOrder = playerSprite.sortingOrder - 1 + layerOffset;

        }
    }
}
