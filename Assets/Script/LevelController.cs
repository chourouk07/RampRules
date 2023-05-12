using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class LevelController : MonoBehaviour
{
    public Collision collision;
    public GameObject endScreen;

    private void Update()
    {
        if (collision.isDead)
        {
            endScreen.SetActive(true);
        }
    }
}
