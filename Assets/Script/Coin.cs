using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private Score score;
    public AudioSource coinFX;

    private void Start()
    {
        score = FindObjectOfType<Score>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            coinFX.Play();
            score.ScoreCal(1);
            Destroy(gameObject);
        }
    }
}
