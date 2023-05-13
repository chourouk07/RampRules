using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    public AudioSource jumpFX;
    public float moveSpeed = 20.0f;
    public float horizontalSpeed = 2.0f;
    public float jumpForce = 5.0f;
    public float yPosPlayer;

    [SerializeField] private bool isJumping = false;
    [SerializeField] private bool comingDown = false;

    private Animator animator;
    private Transform modelTransform;
    private Quaternion startRotation;

    public float speedIncreaseRate = 0.1f; // The rate at which the player speed increases
    public float maxSpeed = 30.0f; // The maximum speed the player can reach

    private void Start()
    {
        yPosPlayer = transform.position.y;
        animator = GetComponentInChildren<Animator>();
        modelTransform = transform.GetChild(0);
        startRotation = modelTransform.localRotation;
    }

    private void Update()
    {
        moveSpeed = Mathf.Min(moveSpeed + speedIncreaseRate * Time.deltaTime, maxSpeed);

        // Move the player forward
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime, Space.World);

        // Move the player horizontally
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.position.x < Screen.width / 2)
            {
                transform.Translate(Vector3.left * Time.deltaTime * horizontalSpeed, Space.World);
                modelTransform.localRotation = Quaternion.Euler(0, -20, 0);
            }
            else if (touch.position.x > Screen.width / 2)
            {
                transform.Translate(Vector3.right * Time.deltaTime * horizontalSpeed, Space.World);
                modelTransform.localRotation = Quaternion.Euler(0, 20, 0);
            }
        }
        else
        {
            modelTransform.localRotation = Quaternion.Lerp(modelTransform.localRotation, startRotation, Time.deltaTime * 10.0f);
        }

        // Jump if the swipe up is detected and the player is not already jumping
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended && !isJumping)
        {
            // Check for swipe gesture
            Vector2 swipeDelta = Input.GetTouch(0).deltaPosition;
            if (swipeDelta.y > 0)
            {
                // Perform jump
                isJumping = true;
                animator.SetTrigger("Jump");
                jumpFX.Play();
                StartCoroutine(JumpSequence());
            }
        }

        // Apply jump force if the player is jumping
        if (isJumping)
        {
            if (!comingDown)
            {
                transform.Translate(Vector3.up * Time.deltaTime * jumpForce, Space.World);
            }
            else
            {
                transform.Translate(-Vector3.up * Time.deltaTime * jumpForce, Space.World);
                StartCoroutine(ReturnToEarth());
            }
        }
    }

 private IEnumerator JumpSequence()
    {
        yield return new WaitForSeconds(0.5f);
        comingDown = true;
        yield return new WaitForSeconds(0.5f);
        isJumping = false;
        comingDown = false;
    }

    private IEnumerator ReturnToEarth()
    {
        yield return new WaitForSeconds(0.4f);
        transform.position = new Vector3(transform.position.x, yPosPlayer, transform.position.z);
    }
}

