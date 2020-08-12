using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public float multiplier;

    public float movementSpeed = 5f;

    public Rigidbody2D rb;

    public Animator animator;

    Vector2 movement;

    void Start()
    {
        transform.position = GameManager.overworldPos;
        multiplier = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        //input
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        animator.SetFloat("RightSpeed", movement.x);
        animator.SetFloat("UpSpeed", movement.y);

        if (Input.GetKey(KeyCode.LeftShift))
            multiplier = 3;
        
        if (Input.GetKeyUp(KeyCode.LeftShift))
            multiplier = 1;


    }

    void Movement()
    {
        //movement
        rb.MovePosition(rb.position + movement * movementSpeed  * multiplier* Time.fixedDeltaTime);
    }

    void FixedUpdate()
    {
        Movement();
    }
}
