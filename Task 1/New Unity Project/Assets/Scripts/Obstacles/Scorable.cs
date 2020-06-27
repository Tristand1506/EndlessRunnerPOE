using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scorable : MonoBehaviour
{
    GameObject player;
    bool hasScored;
    // Start is called before the first frame update
    void Start()
    {
        hasScored = false;
        player = GameObject.FindGameObjectWithTag("Player");
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
