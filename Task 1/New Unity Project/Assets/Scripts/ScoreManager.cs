using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
    
    
{
    int score;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
    }

    public void scoreUp()
    {
        score ++;
        this.transform.GetChild(0).GetComponent<UIManager>().UpdateScore(score);
        Debug.Log("Score:" + score);
    }
    // Update is called once per frame
    
}
