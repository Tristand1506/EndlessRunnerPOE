using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Despawner : MonoBehaviour
{
    public GameObject corridor;
    public int forwardTileCount;
    int zProgress;
    void Start()
    {
        zProgress = 0;
        for (int i = 0; i < forwardTileCount; i++)
        {
            Object.Instantiate(corridor, new Vector3(0, 0, zProgress), Quaternion.identity);
            zProgress += 6;
        }
    }
    

    void OnTriggerEnter(Collider collider)
    {
        Debug.Log("Destroying object: " + collider.gameObject);
        if (collider.gameObject.tag=="Enviroment")
        {
            Destroy(collider.gameObject);
            Object.Instantiate(corridor, new Vector3(0, 0, zProgress), Quaternion.identity);
            zProgress += 6;
        }
        
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(0,0,0,0.4f);
        Gizmos.DrawCube(transform.position, new Vector3(40,10,6));

    }

    

}
