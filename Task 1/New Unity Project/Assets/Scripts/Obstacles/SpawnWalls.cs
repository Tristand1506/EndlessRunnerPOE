using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnWalls : MonoBehaviour
{
    float Xoff;
    float Zoff;

    public int[,] heights = new int[12, 6];
    int lastHeight = -1;

    Vector2 dimentions = new Vector2(12, 6);
    public GameObject varblock;
    public int maxHeight;
    Transform[,] blocks;
    // Start is called before the first frame update
    void Start()
    {

        float Xoff = transform.position.x;
        float Zoff = transform.position.z;
        
        // 12x6
        blocks = new Transform[12, 6];
        

        for (int y = 0; y < dimentions.y; y++)
        {
            for (int x = 0; x < dimentions.x; x++)
            {
                //heights[x, y] = Random.Range(0, maxHeight);

                var ran = GenerateRandom(x,y, heights);
                lastHeight = ran;
                heights[x, y] = ran+1;

                for (int z = 0; z < heights[x, y]; z++)
                {
                    GameObject newBlock = Object.Instantiate(varblock, new Vector3(x + Xoff, z + 0.5f, y + Zoff), Quaternion.identity);
                    newBlock.transform.SetParent(this.transform);
                }

                //for (int z = 0; z < heights[x, y]; z++)
                //{
                //   GameObject newBlock = Object.Instantiate(varblock, new Vector3(x+Xoff, z+0.5f, y+Zoff), Quaternion.identity);
                //    newBlock.transform.SetParent(this.transform);
                //}


                //blocks[x, y].transform.position = new Vector3(x + Xoff, perlin, y + Zoff);

            }
        }

        
        
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawCube(transform.position, Vector3.one);

    }

    private int GenerateRandom(int _x, int _y, int[,] _arr)
    {
        if (lastHeight == -1) { return Random.Range(0, maxHeight); }

        if (_y == 0)
        {
            int ran = Random.Range(lastHeight - 1, lastHeight + 1);
            Mathf.Clamp(ran, 0, maxHeight);
            return ran;
        }
        else
        {
            var adjacent = _arr[_x , _y - 1];
            int ran = Random.Range(adjacent - 1, adjacent + 1);

            while (ran < adjacent -1 || ran >adjacent +1)
            {
                ran = Random.Range(adjacent - 1, adjacent + 1);
            }

            Mathf.Clamp(ran, 0, maxHeight);
            return ran;

        }

        //int ran = Random.Range(lastHeight-2, lastHeight+2);
        //Mathf.Clamp(ran, 0, maxHeight);
        
    }

}
