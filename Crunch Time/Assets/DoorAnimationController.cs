using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorAnimationController : MonoBehaviour
{
    public Animator doorAnimation;


    void OnTriggerEnter2D(Collider2D other)
    {
        doorAnimation.SetBool("Open", true);
    }

    void OnTriggerExit2D(Collider2D other)
    {
        doorAnimation.SetBool("Open", false);
    }
}
