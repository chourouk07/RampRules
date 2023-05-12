using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cars : MonoBehaviour
{
    public float speed = 40f;
    public float maxDistance = 60f;
    public bool isMovingRight = true; // Set this to false for cars that move left

    private Vector3 initialPosition;

    private void Start()
    {
        // Store the initial position of the car
        initialPosition = transform.position;
    }

    private void Update()
    {
        // Determine the direction of movement based on the value of isMovingRight
        Vector3 direction = isMovingRight ? Vector3.right : Vector3.left;

        // Translate the GameObject on the x-axis based on the value of speed and direction
        transform.Translate(direction * speed * Time.deltaTime);

        // Check if the car has exceeded the max distance
        if (Mathf.Abs(transform.position.x - initialPosition.x) >= maxDistance)
        {
            // Reset the position of the car to its initial position
            transform.position = initialPosition;
        }
    }
}


