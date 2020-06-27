using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupWings : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Fly Time!!!");
            PlayerController.instance.TakeOff();
        }
    }
}
