using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
        
    CharacterController controller;

    public float speed = 12;
    float gravity = -9.81f;

    public Transform groundcheck;
    public float groundDistance = 0.4f;
    public LayerMask GroundMask;

    Vector3 velocity;
    bool isGroundedl;


    void Start()
    {
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

        controller.isGrounded






    }
}
