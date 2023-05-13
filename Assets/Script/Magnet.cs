using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magnet : MonoBehaviour
{
    public GameObject player;
    [SerializeField] private float magnetRadius = 5f;
    [SerializeField] private float magnetSpeed = 10f;
    [SerializeField] private float magnetDuration = 10f; // duration of magnet powerup in seconds
   [SerializeField] private AudioSource magnetSound; // sound effect to play when magnet is activated

    [SerializeField] private bool isMagnetActive = false; // flag to indicate whether magnet powerup is active
    private float magnetTimer = 0f; // timer for magnet powerup duration

    private void FixedUpdate()
    {
        if (isMagnetActive)
        {
            gameObject.transform.position = player.transform.position;
            magnetTimer -= Time.deltaTime;
            if (magnetTimer <= 0f)
            {
                isMagnetActive = false;
            }
        }

        if (isMagnetActive)
        {
            Collider[] colliders = Physics.OverlapSphere(transform.position, magnetRadius);

            foreach (Collider collider in colliders)
            {
                if (collider.CompareTag("Coin"))
                {
                    Vector3 direction = (transform.position - collider.transform.position).normalized;
                    collider.transform.position += direction * magnetSpeed * Time.deltaTime;
                }
            }


        }
        if (!isMagnetActive && magnetSound.isPlaying)
        {
            magnetSound.Stop();
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
         if (other.CompareTag("Player"))
        {
            if (!isMagnetActive)
            {
                Renderer renderer1 = gameObject.transform.GetChild(0).GetComponent<Renderer>();
                renderer1.enabled = false;
                Renderer renderer2 = gameObject.transform.GetChild(1).GetComponent<Renderer>();
                renderer2.enabled = false;
                isMagnetActive = true;
                magnetTimer = magnetDuration;
                if (magnetSound != null)
                {
                    magnetSound.Play();
                }

            }
        }
    }
}
