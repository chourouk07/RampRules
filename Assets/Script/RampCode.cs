using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RampCode : MonoBehaviour
{
    [SerializeField] private bool onRamp ;
    [SerializeField] private float initPosy;
    [SerializeField] private bool inAir ;
    [SerializeField] private GameObject player; 

    // Start is called before the first frame update
    void Start()
    {
        initPosy = player.transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (onRamp)
        {
            StartCoroutine(RampSequence());
            if (!inAir)
            {
                player.transform.Translate(Vector3.up * Time.deltaTime * 15f, Space.World);
            }
            else
            {
                player.transform.Translate(- Vector3.up * Time.deltaTime * 15f, Space.World);
            }
        }      

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            inAir = false;
            onRamp = true;
            initPosy = player.transform.position.y;
        }
    }


    private IEnumerator RampSequence()
    {
        yield return new WaitForSeconds(1f);
        inAir =true;
        yield return new WaitForSeconds(1f);
        onRamp = false;
        inAir = false;
    }


}

