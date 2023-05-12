using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour
{
    private float groundLevel;
    private Animator animator;
    public GameObject levelControl;
    public bool isDead = false;
    public AudioSource hitFX;

    private void Start()
    {
        animator = GetComponentInChildren<Animator>();
        groundLevel = -3.47f;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstacle"))
        {
            // Freeze movement
            // Fall animation
            hitFX.Play();
            Debug.Log("Collision");
            other.gameObject.GetComponent<Collider>().enabled = false;
            gameObject.GetComponent<PlayerController>().enabled = false;
            transform.position = new Vector3(transform.position.x, groundLevel, transform.position.z);
            animator.Play("Sweep Fall");
            levelControl.GetComponent<DistanceCount>().enabled = false;
            isDead = true;
        }
    }
}


