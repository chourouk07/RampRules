using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DistanceCount : MonoBehaviour
{
    public TextMeshProUGUI disDisplay;
    public TextMeshProUGUI disEndDisplay;
    public int disRun;
    public bool addingDis = false;


    // Update is called once per frame
    void Update()
    {
        if (!addingDis)
        {
            StartCoroutine(AddingDis());
        }
    }

    IEnumerator AddingDis()
    {
        addingDis = true;
        disRun += 1;
        disDisplay.text = "Distance :" + disRun.ToString();
        disEndDisplay.text = "Distance :" + disRun.ToString();
        yield return new WaitForSeconds(0.25f);
        addingDis = false;
    }
}

