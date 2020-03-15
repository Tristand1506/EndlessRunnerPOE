using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    private int missileCount;
    public GameObject missile;

    // Start is called before the first frame update
    void Start()
    {
        missileCount =0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space") && missileCount > 0)
        {
            Object.Instantiate(missile, this.transform.position + new Vector3(0, 1, 0), Quaternion.Euler(0, 0, 0));
            missileCount -= 1;
            //Debug.Log("Missiles Left: " + missileCount);
        }
    }

    public void AddMissile(int ammo)
    {
        missileCount += ammo;
        //Debug.Log("Missiles Added: " + missileCount);
    }
    public int GetMissiles()
    {
        return missileCount;
    }
}
