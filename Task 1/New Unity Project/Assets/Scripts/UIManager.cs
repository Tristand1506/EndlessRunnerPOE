﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    GameObject lives;
    GameObject missile;
    GameObject score;
    GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Controller");
        lives = this.transform.GetChild(0).gameObject;
        missile = this.transform.GetChild(1).gameObject;
        score = this.transform.GetChild(2).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        lives.GetComponent<Text>().text = "Lives: "+player.GetComponent<PlayerController>().GetLives();

        if (player.GetComponent<PlayerController>().GetLives() == 0) 
        {
            this.transform.GetChild(3).GetComponent<Text>().enabled = true;
        }

        missile.GetComponent<Text>().text = player.transform.GetChild(2).GetComponent<Shoot>().GetMissiles() + " :Missiles";    
    }

    public void UpdateScore(int scoreIn)
    {
        score.GetComponent<Text>().text = "" + scoreIn;
    }

}
