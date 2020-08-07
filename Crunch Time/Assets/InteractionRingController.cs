using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionRingController : MonoBehaviour
{
    public GameObject interactionRing;
    bool inProximity;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (inProximity)
            interactionRing.SetActive(true);

        if (inProximity==false)
            interactionRing.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        inProximity = true;
    }
    
    void OnTriggerExit2D(Collider2D other)
    {
        inProximity = false;
    }
}
