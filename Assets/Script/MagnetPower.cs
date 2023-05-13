using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagnetPower : MonoBehaviour
{
    public bool magnetEffect = false;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Magnet"))
        {
            magnetEffect= true;
        }
    }
}
