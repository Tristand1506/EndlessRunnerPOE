using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnWalls : MonoBehaviour
{
    float Xoff;
    float Zoff;

    Vector2 dimentions = new Vector2(12, 6);
    public GameObject varblock;
    
    public float scale;
    public int amplitude;
    Transform[,] blocks;
    // Start is called before the first frame update
    void Start()
    {

        float Xoff = transform.localPosition.x;
        float Zoff = transform.localPosition.z;
        // 12x6
        blocks = new Transform[12, 6];

        for (int x = 0; x < dimentions.x; x++)
        {
            for (int y = 0; y < dimentions.y; y++)
            {
                
                int perlin = Mathf.Clamp(((int)((Mathf.PerlinNoise(x * scale +Time.fixedTime, y * scale+ Time.fixedTime)) *10)),0,amplitude);
                perlin = (perlin * -1) + amplitude;
                Debug.Log(""+perlin);

                blocks[x, y] = Object.Instantiate(varblock, new Vector3(x + Xoff, perlin+0.5f, y + Zoff), Quaternion.identity).transform;
                blocks[x, y].transform.SetParent(this.transform);
                //blocks[x, y].transform.position = new Vector3(x + Xoff, perlin, y + Zoff);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        for (int x = 0; x < dimentions.x; x++)
        {
            for (int y = 0; y < dimentions.y; y++)
            {

                

            }
        }

    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawCube(transform.position, Vector3.one);

    }
}
