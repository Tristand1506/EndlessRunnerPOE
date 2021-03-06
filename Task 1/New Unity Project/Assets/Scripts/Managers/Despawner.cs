﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Despawner : MonoBehaviour
{
    public GameObject corridorSpawn;
    public GameObject corridorStart;
    public GameObject bossCorridor;
    public int forwardTileCount;
    int zProgress;
    void Start()
    {
        //tracks the current z position of tlie spawm for initial blank spawn
        zProgress = 0;
        for (int i = 0; i < forwardTileCount; i++)
        {
            //spawns corridor at "zProgress" and ofsets it by 6
            Object.Instantiate(corridorStart, new Vector3(0, 0, zProgress), Quaternion.identity);
            zProgress += 6;
        }
    }
    

    void OnTriggerEnter(Collider collider)
    {
        //Debug.Log("Destroying object: " + collider.gameObject);
        if (collider.gameObject.tag == "Enviroment")
        {
            Destroy(collider.gameObject);
            switch (GameManager.instance.GetGameStage())
            {
                case 0:
                    Object.Instantiate(corridorSpawn, new Vector3(0, 0, zProgress), Quaternion.identity);
                    break;
                
                case 1:
                    Object.Instantiate(bossCorridor, new Vector3(0, 0, zProgress), Quaternion.identity);
                    break;
            }
            
            zProgress += 6;
        }
        
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(0,0,0,0.4f);
        Gizmos.DrawCube(transform.position, new Vector3(40,10,6));

    }

    

}
