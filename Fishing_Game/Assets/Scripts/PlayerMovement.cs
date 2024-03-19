using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
        
    CharacterController controller;

    [SerializeField]
    float speed = 3;
    [SerializeField]
    float sprintSpeed = 6;

    float jumpHeight = 2;

    float coyoteTime = 0.1f;

    float coyoteTimeCount;

    float startSpeed; // is om de speed te bewaren 


    float gravity = -9.81f;


    [SerializeField]
    Vector3 velocity;


    void Start()
    {
       startSpeed = speed;
       controller = GetComponent<CharacterController>();
    }

    void Update()
    {

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);


        if (controller.isGrounded)
        {
            coyoteTimeCount = coyoteTime;
            velocity.y = -1;
        }
        else
        {
            coyoteTimeCount -= Time.deltaTime;
        }


        if (coyoteTimeCount > 0f && Input.GetAxis("Jump") > 0)
        {
            velocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravity);
            coyoteTimeCount = 0f;
        }

        velocity.y += gravity * Time.deltaTime * 0.5f;
        controller.Move(velocity* Time.deltaTime);



        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = sprintSpeed;
        }
        else
        { 
        speed = startSpeed;
        }
    }


}
