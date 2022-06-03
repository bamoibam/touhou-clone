using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ScenesManager : MonoBehaviour
{
    public void GameOver()
    {
        SceneManager.LoadScene("GameOver");
        //Debug.Log("Total Score: " + GetComponent<ScoreManager>().PlayerScore);
    }
}
