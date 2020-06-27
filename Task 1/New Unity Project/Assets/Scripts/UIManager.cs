using System.Collections;
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
        score.GetComponent<Text>().text = "" + GameManager.instance.GetScore();

        lives.GetComponent<Text>().text = "Lives: "+PlayerController.instance.health;

        //if (GameManager.instance.health == 0) 
        //{
        //    this.transform.GetChild(3).GetComponent<Text>().enabled = true;
        //}

        missile.GetComponent<Text>().text = PlayerController.instance.missileCount+ " :Missiles";    
    }

   

}
