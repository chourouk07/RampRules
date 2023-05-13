using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RampCode : MonoBehaviour
{
    public AudioSource jumpFX;
    [SerializeField] private bool onRamp;
    [SerializeField] private bool inAir;
    [SerializeField] private GameObject player;
    public Animator animator;



    // Update is called once per frame
    void Update()
    {
        if (onRamp)
        {
            StartCoroutine(RampSequence());
            if (!inAir)
            {
                player.transform.Translate(Vector3.up * Time.deltaTime * 10f, Space.World);

            }
            else
            {
                player.transform.Translate(-Vector3.up * Time.deltaTime * 10f, Space.World);
            }
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            jumpFX.Play();
            animator.SetTrigger("Jump");
            inAir = false;
            onRamp = true;
        }
    }


    private IEnumerator RampSequence()
    {
        yield return new WaitForSeconds(1f);
        inAir = true;
        yield return new WaitForSeconds(1f);
        onRamp = false;
        inAir = false;
    }


}


