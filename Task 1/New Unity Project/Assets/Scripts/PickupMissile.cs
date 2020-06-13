using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupMissile : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            try
            {
                Debug.Log("Missile touched");
                other.gameObject.GetComponent<Shoot>().AddMissile(2);
                Destroy(this.gameObject);
            }
            catch (System.Exception)
            {            
            }
        }
    }
}
