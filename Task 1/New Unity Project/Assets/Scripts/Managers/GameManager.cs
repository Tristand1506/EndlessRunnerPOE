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

    void Start()
    {
        PlayerController.instance.onDeath += GameEnd;
        
    }

     void Update()
    {
        if (Input.GetKeyDown("r"))
        {
            this.Restart();
        }    
    }

    //######
    //events
    //######


    public event Action scoreUp;

    //#######
    //globals
    //#######

    int stageTrigger = 500;

    int STAGE_INTERVAL = 500;
    int score = 0;
    int gameStage = 0;

    //Game Objects
    public GameObject boss1;




    //score stuff
    public void ScoreIncriment()
    {
        scoreUp?.Invoke();
        score++;
        if (score > stageTrigger && gameStage!=1 && !PlayerController.instance.isFlying())
        {
            gameStage = 1;
            UnityEngine.Object.Instantiate(boss1, new Vector3(0, 10, PlayerController.instance.transform.position.z - 20), Quaternion.Euler(0,90,0));
        }
    }
    public void ScoreReset()
    {
        score = 0;
    }
    public int GetScore()
    {
        return score;
    }
    public int GetGameStage()
    {
        
        return gameStage;
        
    }

    // damage method
    

    // scene management

    void GameEnd()
    {
        Debug.Log("you died");
        SceneManager.LoadScene("YouDied");
    }
    void Restart()
    {
        score = 0;
        gameStage = 0;
        SceneManager.LoadScene("Start");
    }

    public void NextStage(int stageNumber)
    {
        gameStage = stageNumber;
        stageTrigger = score + STAGE_INTERVAL;
    }

}
