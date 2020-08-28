using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mine : MonoBehaviour
{

    //#######
    //Globals
    //#######

    public ParticleSystem Explosion;

    public bool holding = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(MineHold());
        if (transform.position.z < PlayerController.instance.transform.position.z - 10)
        {
            Destroy(this.gameObject);
        }
    }

    public void Explode()
    {
        if (holding)
        {
            Boss1Handler.instance.oof();
        }
        ParticleSystem boom = GameObject.Instantiate(Explosion, this.transform.position, Quaternion.identity);
        boom.Play();
        Destroy(this.gameObject);

    }

    IEnumerator MineHold()
    {
        if (transform.position.y > 0)
        {
            transform.Translate(Vector3.down * Time.deltaTime * 8);
        }
        yield return new WaitForSeconds(3f);

        this.transform.SetParent(null);
        holding = false;

    }
}
