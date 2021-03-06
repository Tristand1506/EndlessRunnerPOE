﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageManager: MonoBehaviour
{

    // player hitbox
    BoxCollider hitBox;

    private void Start()
    {
        //subscribing events
        PlayerController.instance.onOof += immune;

        //assigns Boxcollider
        hitBox = this.gameObject.GetComponent<BoxCollider>();
    }

    private void OnTriggerEnter(Collider collision)
    {
        Debug.Log("Collision");
        if (collision.transform.tag == "CanDamage")
        {
            PlayerController.instance.Oof(1);

            if (collision.gameObject.GetComponent<Mine>() != null)
            {
                collision.gameObject.GetComponent<Mine>().Explode();
            }

            Debug.Log("You Did A Crash!!!");
            // minus one life
        }
        if (collision.transform.tag == "Boost")
        {
            PlayerController.instance.SpeedUp(1f);
            Debug.Log("Boost!!!");
            //Incrimenmts speed by 1...
        }
    }

    void immune()
    {
        StartCoroutine(hitBoxOff());
    }

    IEnumerator hitBoxOff()
    {
        hitBox.enabled = false;
        yield return new WaitForSeconds(1);
        hitBox.enabled = true;
    }
}
