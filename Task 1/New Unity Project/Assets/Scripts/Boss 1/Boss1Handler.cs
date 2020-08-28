using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;

public class Boss1Handler : MonoBehaviour
{
    // singleton

    public static Boss1Handler instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    //######
    //Events
    //######

    public event Action Destroyed;
    
    //#######
    //Globals
    //#######

    int health = 10;
    int HEALTH_MAX = 10;

    public ParticleSystem SmokeStack;

    public ParticleSystem Fire;

    public ParticleSystem Explosion;

    public GameObject Mine;

    bool entering = true;
    bool flyIn = true;

    bool rotate = false;

    bool isAttacking = false;


    //###############
    //Attack Patterns
    //###############

    string[] _sweep = new string[9] {"0","1","2","3","4","3","2","1","0"};

    string[] _alt = new string[5] { "04", "13", "2", "13", "04"};

    string[] _wall = new string[5] { "01234", "01234", "01234", "01234", "01234" };

    string[] _tunnle = new string[5] { "0134", "0123", "0234", "1234", "0124" };



    // Update is called once per frame
    void Update()
    {
        //enter animation scripts
        if (this.transform.position.z < PlayerController.instance.transform.position.z + 40 && flyIn)
        {
            this.transform.Translate(Vector3.left * Time.deltaTime * PlayerController.instance.GetSpeed() * 1.5f);
        }
        else if (flyIn)
        {
            flyIn = false;
            rotate = true;
            Debug.Log("Enter Done /n rotating...");
        }
        else if (rotate)
        {
            Debug.Log("rotating...");

            this.transform.Translate(Vector3.forward * Time.deltaTime * PlayerController.instance.GetSpeed(), Space.World);
            this.transform.Rotate(Vector3.down * Time.deltaTime * 50);
            if (this.transform.position.y>8)
            {
                this.transform.Translate(Vector3.down * Time.deltaTime , Space.World);
            }
            Debug.Log("Rotate is at..." + transform.rotation.y);
            if (this.transform.rotation.y < -0.70f)
            {
                Debug.Log("Rotate compleate....... Locking");
                this.transform.rotation = Quaternion.Euler(0, -90, 0);
                rotate = false;
                entering = false;
            }
        }

        // normal movement
        if (!entering)
        {
            this.transform.Translate(Vector3.right * Time.deltaTime * PlayerController.instance.GetSpeed());
        }

        if (!isAttacking && !entering)
        {
            Debug.Log("Starting Attack");
            StartCoroutine(MineSpawn(_tunnle));
        }

        
        

    }

    void SpawnMine(int slot)
    {
        GameObject mineSpawn;
        switch (slot)
        {
            case 0:
                mineSpawn = UnityEngine.Object.Instantiate(Mine, new Vector3(-4, this.transform.position.y-1, transform.position.z), Quaternion.identity);
                mineSpawn.transform.SetParent(this.transform);
                break;
            case 1:
                mineSpawn = UnityEngine.Object.Instantiate(Mine, new Vector3(-2, this.transform.position.y - 1, transform.position.z), Quaternion.identity);
                mineSpawn.transform.SetParent(this.transform);
                break;
            case 2:
                mineSpawn = UnityEngine.Object.Instantiate(Mine, new Vector3(0, this.transform.position.y - 1, transform.position.z), Quaternion.identity);
                mineSpawn.transform.SetParent(this.transform);
                break;
            case 3:
                mineSpawn = UnityEngine.Object.Instantiate(Mine, new Vector3(2, this.transform.position.y - 1, transform.position.z), Quaternion.identity);
                mineSpawn.transform.SetParent(this.transform);
                break;
            case 4:
                mineSpawn = UnityEngine.Object.Instantiate(Mine, new Vector3(4, this.transform.position.y - 1, transform.position.z), Quaternion.identity);
                mineSpawn.transform.SetParent(this.transform);
                break;
        }
    }

    // damage boss 
    public void oof()
    {
        health--;
        Debug.Log("Health at: " + health);

        

        if (health <= 0)
        {
            GameObject.Instantiate(Explosion, transform.position, Quaternion.identity).Play();
            Destroyed?.Invoke();
            GameManager.instance.NextStage(0);
            Destroy(this.gameObject);
        }
    }

    public int getHealth()
    {
        return health;
    }

    IEnumerator MineSpawn(string[] spawnPattern)
    {
        isAttacking = true;

        for (int i = 0; i < spawnPattern.Length; i++)
        {
            yield return new WaitForSeconds(1f);
            Debug.Log("dispencing mine.....");
            for (int j = 0; j < spawnPattern[i].Length; j++)
            {
                SpawnMine(Int32.Parse((spawnPattern[i])[j]+""));
            }
        }

        yield return new WaitForSeconds(5f);
        isAttacking = false;
    }
    
    
}



