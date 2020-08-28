using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileBehavior : MonoBehaviour
{
    public float speed;
    bool isAlive;


    // Start is called before the first frame update
    void Start()
    {
        speed += PlayerController.instance.speed;
        isAlive = true;

        AudioManager.instance.Play("ArcadeSounds_shot32");
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Translate(Vector3.forward * Time.deltaTime * speed);
        if (!isAlive)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("CanDamage"))
        {
            //Debug.Log("hit");
            if (other.gameObject.GetComponent<Mine>() != null)
            {
                other.gameObject.GetComponent<Mine>().Explode();
                isAlive = false;
            }
            else
            {
                Destroy(other.gameObject);
                isAlive = false;
            }
        }
    }
}
