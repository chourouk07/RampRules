using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move2 : MonoBehaviour
{
    public float speed = 5.0f;
    public float jumpForce = 5.0f;
    public float gravity = 20.0f;

    private CharacterController controller;
    private Vector3 moveDirection = Vector3.zero;
    private bool isGrounded;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        // Move the skater forward automatically
        Vector3 forwardMovement = transform.forward * speed;

        // Move the skater horizontally
        float horizontalInput = Input.GetAxis("Horizontal");
        Vector3 horizontalMovement = transform.right * horizontalInput * speed;

        // Combine the forward and horizontal movement vectors
        Vector3 movement = forwardMovement + horizontalMovement;

        // Apply gravity to the skater
        moveDirection.y -= gravity * Time.deltaTime;

        // Jump if the skater is grounded and the jump button is pressed
        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            moveDirection.y = jumpForce;
        }

        // Move the skater using the character controller
        controller.Move(movement * Time.deltaTime + moveDirection * Time.deltaTime);

        // Check if the skater is grounded
        isGrounded = controller.isGrounded;
    }
}
