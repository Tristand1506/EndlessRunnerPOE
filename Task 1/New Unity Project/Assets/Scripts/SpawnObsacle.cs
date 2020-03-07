using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObsacle : MonoBehaviour
{
    public GameObject barrSmall;
    public GameObject barrLarge;
    public GameObject spike;
    int[,] obstacles;
    
   


    // Start is called before the first frame update
    void Start()
    {
        obstacles = new int[5, 3];


        for (int x = 0; x < 5; x++)
        {
            for (int y = 0; y < 3; y++)
            {
                GameObject spawned;
                obstacles[x, y] = Random.Range(0, 30);

                Vector3 pos = new Vector3(this.transform.position.x - 4 +(x*2), 0, this.transform.position.z + 2 - (y*2));

                switch (obstacles[x,y])
                {
                    case 10:
                        spawned = Object.Instantiate(spike, pos, Quaternion.identity);
                        spawned.transform.SetParent(this.transform);
                        break;
                    case 20:
                        spawned = Object.Instantiate(barrLarge, pos, Quaternion.identity);
                        spawned.transform.SetParent(this.transform);
                        break;
                    case 15:
                        spawned = Object.Instantiate(barrSmall, pos, Quaternion.identity);
                        spawned.transform.SetParent(this.transform);
                        break;

                    default:
                        break;
                        
                }
            }
        }

        for (int j = 0; j < 3; j++)
        {
            string adx = "";
            for (int i = 0; i < 5; i++)
            {
                adx += obstacles[i, j] + "-";


            }
            Debug.Log(j + ":" + adx);
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
