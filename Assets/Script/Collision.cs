using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour
{
    private float posY;
    private Animator animator;
    private void Start()
    {
        animator= GetComponentInChildren<Animator>();
        posY = gameObject.GetComponent<PlayerController>().yPosPlayer;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstacle"))
        {
            //freeze movement
            //fall animation
            Debug.Log("Collision");
            other.gameObject.GetComponent<Collider>().enabled = false;
            gameObject.GetComponent<PlayerController>().enabled = false;
            transform.position = new Vector3(transform.position.x, posY, transform.position.z);
            animator.Play("Sweep Fall");
        }
    }
}
