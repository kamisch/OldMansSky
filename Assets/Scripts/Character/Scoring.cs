using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scoring : MonoBehaviour {

    public Image currentScoreBar;
    public Text ratioText;

    private float scorePoint = 0;

    private void Start()
    {
        UpdateScore();
    }
    private void UpdateScore()
    {
        ratioText.text = scorePoint.ToString();
        if (scorePoint > 10000 && scorePoint < 100000)
        {
            currentScoreBar.color = Color.red;
        }
        if (scorePoint > 100000 && scorePoint < 1000000)
        {
            currentScoreBar.color = Color.yellow;
        }
    }


    private void ConstantAdd()
    {
        scorePoint += 1;
        UpdateScore();
    }

    private void itemAdd( float amount)
    {
        scorePoint += amount;
        UpdateScore();
    }
    public void SaveDeathScore()
    {
        if (PlayerPrefs.GetFloat("HighScore") < scorePoint)
            PlayerPrefs.SetFloat("HighScore", scorePoint);
    }

}
