using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeathScreenManager : MonoBehaviour
{
    GameObject scoreNumber;

    // Start is called before the first frame update
    void Start()
    {
        scoreNumber = transform.GetChild(2).gameObject;
        scoreNumber.GetComponent<Text>().text = ""+GameManager.instance.GetScore();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
