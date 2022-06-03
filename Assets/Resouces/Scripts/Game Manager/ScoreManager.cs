using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    private static int score;
    public int Score
    {
        get
        {
            return score;
        }
    }

    public void SetScore(int incomingScore)
    {
        score += incomingScore;
        Debug.Log("Score: " + score);
    }
    public void ResetScore()
    {
        score = 000000;
    }
}
