using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private int coins = 0;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            coins++;
            Destroy(gameObject);
        }
    }
}
