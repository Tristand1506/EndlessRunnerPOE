using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupMissile : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //Debug.Log("Missile touched");
            PlayerController.instance.missileCount += 3;
            //Destroy(this.gameObject);
        }
    }
}
