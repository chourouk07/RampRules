using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5.0f;
    public float horizontalSpeed = 2.0f;
    public float jumpForce = 5.0f;
    public float yPosPlayer;

    [SerializeField] private bool isJumping = false;
    [SerializeField] private bool comingDown = false;


    private Animator animator;

    private void Start()
    {
        yPosPlayer = transform.position.y;
        animator = GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        // Move the player forward
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime, Space.World);

        // Move the player horizontally
        if (Input.GetAxis("Horizontal") > 0)
        {
            transform.Translate(Vector3.right * Time.deltaTime * horizontalSpeed, Space.World);
        }
        else if (Input.GetAxis("Horizontal") < 0)
        {
            transform.Translate(Vector3.left * Time.deltaTime * horizontalSpeed, Space.World);
        }

        // Jump if the jump button is pressed and the player is not already jumping
        if (Input.GetButtonDown("Jump") && !isJumping)
        {
            isJumping = true;
            animator.SetTrigger("Jump");
            StartCoroutine(JumpSequence());
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
