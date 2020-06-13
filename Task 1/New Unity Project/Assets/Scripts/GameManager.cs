using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //implimenting singleton method
    public static GameManager instance { get; private set; }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

    }

    //######
    //events
    //######

    public event Action scoreUp;

    //#######
    //globals
    //#######

    int score = 0;

    //score stuff
    public void ScoreIncriment()
    {
        scoreUp?.Invoke();
        score++;
    }
    public void ScoreReset()
    {
        score = 0;
    }
    public int GetScore()
    {
        return score;
    }

    // damage method
    

    // scene management


}
