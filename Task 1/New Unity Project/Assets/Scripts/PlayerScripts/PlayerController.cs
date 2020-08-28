using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerController : MonoBehaviour
{

    //creating singleton instance of player controller
    public static PlayerController instance;

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
    //events
    //######

    //damage and death
    public event Action onOof;
    public event Action onDeath;

    //movement
    public event Action onMoveLeft;
    public event Action onMoveRight;
    public event Action onJunp;

    public event Action onGrindDown;
    public event Action onGrindUp;

    public event Action onMisileFire;

    //########
    // globals
    //########

    //referance to player 
    public GameObject player;

    public GameObject wingPrefab;
    private GameObject wing;
    private int _MissileCount;
    public int health = 3;
    private int _lane;
    private float _baseSpeed;
    public float speed;

    private bool flying = false;
    private bool alive = true;
    private bool grind = false;
    private bool jump = false;
    private bool reloading = false;
    
    //###########
    // Properties
    //###########

    //lane clamp get and set
    public int lane{

        get { return _lane; }
        set {
            int direction = _lane;
            if (lane != (_lane = Mathf.Clamp(value, -2, 2)))
            {
                // invokes left event if negative value
                if (direction > value)
                {
                    onMoveLeft?.Invoke();
                    //Debug.Log("invoke left");
                }
                //invokes right event if positive
                else if (direction < value)
                {
                    onMoveRight?.Invoke();
                    //Debug.Log("invoke right");
                }
            }   
        }
    }

    public int missileCount
    {
        get { return _MissileCount; }
        set
        {
            if (value<=0)
            {
                _MissileCount = 0;
            }
            _MissileCount = value;
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        _baseSpeed = speed;
        //event subscriptions
        GameManager.instance.scoreUp += SpeedUp;

        //sets player to alive
        alive = true;
        //instantiates player referance
        player = GameObject.Instantiate(player, new Vector3(0, 1, 5), Quaternion.Euler(-90,0,0));
        //sets parent to this playercontroller game object
        player.transform.SetParent(this.transform);
        lane = 0;

    }

    // Update is called once per frame
    void Update()
    {
        
        //moves player foward based on speed variable.
        this.transform.Translate(Vector3.forward*Time.deltaTime*speed);


        //DEALS WITH FLYING
        if (flying && this.transform.position.y < 10)
        {
            this.transform.Translate(Vector3.up * Time.deltaTime * 5);
        }
        if (!flying && this.transform.position.y > 0)
        {
            if (this.transform.position.y < 0)
            {
                this.transform.position = new Vector3(player.transform.position.x, 0, player.transform.position.z);
            }
            else
            {
                this.transform.Translate(Vector3.down * Time.deltaTime * 5);
            }
        }

        //##########
        //Key inputs
        //##########

        if (alive)
        {

            // cheks if player is "grinding" 
            if (!grind)
            {
                // flags for left movement
                if (Input.GetKeyDown("left"))
                {
                    //Debug.Log("left");
                    //Debug.Log(lane);
                    
                    lane -= 1;
                    player.transform.position = new Vector3(lane*2, player.transform.position.y, player.transform.position.z);
                }

                // flags for right movement
                if (Input.GetKeyDown("right"))
                {
                    //Debug.Log("right");
                    //Debug.Log(lane);
                    
                    lane += 1;
                    player.transform.position = new Vector3(lane*2, player.transform.position.y, player.transform.position.z);
                }
            }


            if (!flying)
            {
                //Missile Input
                if (Input.GetKeyDown("space") && !reloading && missileCount > 0)
                {
                    FireMissile();
                }

                //jump input
                if (Input.GetKeyDown("up") && !jump)
                {
                    //Debug.Log("jump");
                    StartCoroutine(Jumping());
                }

                //grind down input
                if (Input.GetKeyDown("down"))
                {
                    //Debug.Log("Slammin!!!");
                    jump = false;
                    grind = true;
                    onGrindDown?.Invoke();
                }

                //grind up input
                if (Input.GetKeyUp("down"))
                {
                    //Debug.Log("SlamminOFF");
                    grind = false;
                    onGrindUp?.Invoke();
                }
            }
            
        }

    }

    //#######
    //Methods
    //#######

    

    public bool isFlying()
    {
        return flying;
    }

    //speed up method
    public void SpeedUp()
    {
        speed += 0.07f;
    }
    public void SpeedUp(float increase)
    {
        speed += increase;
    }

    //Get Sets

    // gets speed variable
    public float GetSpeed()
    {
        return speed;
    }

    //Roblox method
    public void Oof(int damage)
    {
        //check if health at or lower than 0...
        if (health <= 0)
        {
            speed = 0;
            alive = false;
            onDeath?.Invoke();

            Debug.Log("0 Health");
        }
        else
        {
            if (!flying)
            {
                // subtracts damage and invokes oof...
                health -= damage;
                speed = speed * 0.4f;

                if (speed < _baseSpeed)
                {
                    speed = _baseSpeed;
                }

                onOof?.Invoke();
            }
        }
    }

    public void Heal(int healing)
    {
        health = Mathf.Clamp(health += healing, 0, 3);
    }

    //launch Missile
    public void FireMissile()
    {
        missileCount -= 1;
        StartCoroutine(Reloading());
    }

    public void TakeOff()
    {
        flying = true;

        //spawns wing prefab
        wing = GameObject.Instantiate(wingPrefab, player.transform.GetChild(0).transform.position, player.transform.GetChild(0).transform.rotation);
        wing.transform.SetParent(player.transform.GetChild(0).transform);
        wing.transform.localScale = new Vector3(0.015f, 0.012f, 0.008f);

        //starts flying
        StartCoroutine(flySpeed());

    }

    IEnumerator flySpeed()
    {
        speed += 10;
        yield return new WaitForSeconds(10);
        speed -= 10;
        flying = false;
        Destroy(wing);
    }

    IEnumerator Jumping()
    {
        jump = true;
        onJunp?.Invoke();
        yield return new WaitForSeconds(0.9f);
        jump = false;
    }

    IEnumerator Reloading()
    {
        reloading = true;
        onMisileFire?.Invoke();
        yield return new WaitForSeconds(0.2f);
        reloading = false;
    }




}
