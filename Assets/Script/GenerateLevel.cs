using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateLevel : MonoBehaviour
{
    public GameObject section;
    [SerializeField] private float zPos = 689f;
    [SerializeField] private bool isGenerating = false; 

    private void Update()
    {
     if (!isGenerating)
        {
            isGenerating = true;
            StartCoroutine(CreateLevel());
        }  
    }

    IEnumerator CreateLevel()
    {
        Instantiate(section, new Vector3(0,0,zPos),Quaternion.identity);
        zPos += 689f;
        yield return new WaitForSeconds(40f);
        isGenerating= false;
    }
}
