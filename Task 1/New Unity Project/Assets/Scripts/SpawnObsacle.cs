using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObsacle : MonoBehaviour
{
    public GameObject barrSmall;
    public GameObject barrLarge;
    public GameObject spike;
    public GameObject GrindStone;
    public GameObject missilePack;
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
                obstacles[x, y] = Random.Range(0, 100);

                Vector3 pos = new Vector3(this.transform.position.x - 4 +(x*2), 0, this.transform.position.z + 2 - (y*2));

                if (obstacles[x,y] < 15)
                {
                    int spawnin = Random.Range(0,100);

                    if (spawnin <= 5)
                    {
                        spawned = Object.Instantiate(spike, pos, spike.transform.rotation);
                        spawned.transform.SetParent(this.transform);
                    }
                    else if (spawnin <= 30)
                    {
                        spawned = Object.Instantiate(barrLarge, pos, Quaternion.identity);
                        spawned.transform.SetParent(this.transform);
                    }
                    else if (spawnin <= 65)
                    {
                        spawned = Object.Instantiate(barrSmall, pos, Quaternion.identity);
                        spawned.transform.SetParent(this.transform);
                    }
                    else if (spawnin <= 100)
                    {
                        spawned = Object.Instantiate(GrindStone, pos, Quaternion.identity);
                        spawned.transform.SetParent(this.transform);
                    }
                }
                if (obstacles[x, y]>=99)
                {
                    spawned = Object.Instantiate(missilePack, pos, Quaternion.identity);
                    spawned.transform.SetParent(this.transform);
                }
                
                //switch (obstacles[x,y])
                //{
                //    case 10:
                //        spawned = Object.Instantiate(spike, pos, Quaternion.identity);
                //        spawned.transform.SetParent(this.transform);
                //        break;
                //    case 12:
                //        spawned = Object.Instantiate(barrLarge, pos, Quaternion.identity);
                //        spawned.transform.SetParent(this.transform);
                //        break;
                //    case 21:
                //        spawned = Object.Instantiate(barrLarge, pos, Quaternion.identity);
                //        spawned.transform.SetParent(this.transform);
                //        break;
                //    case 37:
                //        spawned = Object.Instantiate(barrSmall, pos, Quaternion.identity);
                //        spawned.transform.SetParent(this.transform);
                //        break;
                //    case 15:
                //        spawned = Object.Instantiate(barrSmall, pos, Quaternion.identity);
                //        spawned.transform.SetParent(this.transform);
                //        break;

                //    case 35:
                //        spawned = Object.Instantiate(barrSmall, pos, Quaternion.identity);
                //        spawned.transform.SetParent(this.transform);
                //        break;
                //    case 31:
                //        spawned = Object.Instantiate(barrLarge, pos, Quaternion.identity);
                //        spawned.transform.SetParent(this.transform);
                //        break;
                //    case 29:
                //        spawned = Object.Instantiate(barrLarge, pos, Quaternion.identity);
                //        spawned.transform.SetParent(this.transform);
                //        break;
                //    case 48:
                //        spawned = Object.Instantiate(barrSmall, pos, Quaternion.identity);
                //        spawned.transform.SetParent(this.transform);
                //        break;
                //    case 39:
                //        spawned = Object.Instantiate(barrSmall, pos, Quaternion.identity);
                //        spawned.transform.SetParent(this.transform);
                //        break;

                //    case 25:
                //        spawned = Object.Instantiate(barrSmall, pos, Quaternion.identity);
                //        spawned.transform.SetParent(this.transform);
                //        break;


                //    default:
                //        break;
                        
                //}
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
