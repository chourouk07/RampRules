using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    public TextMeshProUGUI coinDisplay;
    public TextMeshProUGUI coinEnd;
    public int scoreCal;

    public void ScoreCal(int coin)
    {
        scoreCal+= coin;
        coinDisplay.text = scoreCal.ToString();
        coinEnd.text = scoreCal.ToString();
    }
}
