using System.Collections;
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
        if (collision.transform.tag == "CanDamage")
        {
            PlayerController.instance.Oof(1);
            Debug.Log("You Did A Crash!!!");
            // minus one life
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
