﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObsacle : MonoBehaviour
{

    //obstacles
    public GameObject barrSmall;
    public GameObject barrLarge;
    public GameObject spike;
    public GameObject GrindStone;

    //pickups
    public GameObject missilePack;
    public GameObject healthWrench;
    public GameObject wings;

    int[,] obstacles;
    
   


    // Start is called before the first frame update
    void Start()
    {
        obstacles = new int[5, 2];


        for (int x = 0; x < 5; x++)
        {
            for (int y = 0; y < 2; y++)
            {
                GameObject spawned;
                //obstacles[x, y] = Random.Range(0, 100);

                Vector3 pos = new Vector3(this.transform.position.x - 4 +(x*2), 0, this.transform.position.z + 2 - (y*2));

                if (Random.value < 0.2f) 
                {
                    if (Random.value < 0.05f)
                    {
                        spawned = Object.Instantiate(spike, pos, spike.transform.rotation);
                        spawned.transform.SetParent(this.transform);
                    }
                    else if (Random.value < 0.3f)
                    {
                        spawned = Object.Instantiate(barrLarge, pos, Quaternion.identity);
                        spawned.transform.SetParent(this.transform);
                    }
                    else if (Random.value < 0.2f)
                    {
                        spawned = Object.Instantiate(GrindStone, pos, Quaternion.identity);
                        spawned.transform.SetParent(this.transform);
                    }
                    else if (Random.value < 0.5f)
                    {
                        spawned = Object.Instantiate(barrSmall, pos, Quaternion.identity);
                        spawned.transform.SetParent(this.transform);
                    }
                }
                else if (Random.value <= 0.01)
                {
                    if (Random.value <= 0.2)
                    {
                        spawned = Object.Instantiate(wings, pos, Quaternion.identity);
                        spawned.transform.SetParent(this.transform);
                    }
                    else if (Random.value <= 0.2)
                    {
                        spawned = Object.Instantiate(healthWrench, pos, Quaternion.identity);
                        spawned.transform.SetParent(this.transform);
                    }
                    else if (Random.value <= 0.6)
                    {
                        spawned = Object.Instantiate(missilePack, pos, Quaternion.identity);
                        spawned.transform.SetParent(this.transform);
                    }
                }
            }
        }

        
    }

    // Update is called once per frame
    void Update()
    {

        
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawCube(transform.position, Vector3.one);

    }
}
