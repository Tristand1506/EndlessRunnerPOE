using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{

    public GameObject missile;

    private void Start()
    {
        PlayerController.instance.onMisileFire += MissileFire;
    }

    void MissileFire()
    {
        Object.Instantiate(missile, this.transform.position + new Vector3(0, 1, 0), Quaternion.Euler(0, 0, 0));
    }
   
}
