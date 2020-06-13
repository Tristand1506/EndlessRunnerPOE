using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleManager : MonoBehaviour
{
    GameObject player;
    GameObject scoreManager;
    bool hasScored;
    // Start is called before the first frame update
    void Start()
    {
        hasScored = false;
        player = GameObject.FindGameObjectWithTag("Player");
        scoreManager = GameObject.FindGameObjectWithTag("ScoreManager");
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasScored && this.transform.position.z < player.transform.position.z)
        {
            GameManager.instance.ScoreIncriment();
            hasScored = true;
        }
    }
}
