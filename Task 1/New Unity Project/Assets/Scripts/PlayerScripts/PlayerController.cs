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

    //########
    // globals
    //########

    //referance to player 
    public GameObject player;

    public int health = 3;
    private int _lane;
    private float _baseSpeed;
    public float speed;
    private bool alive;
    private bool grind = false;
    private bool jump = false;
    
    //###########
    // Properties
    //###########

    //lane clamp get and set
    public int lane{

        get { return _lane; }
        set {
            if (lane != (_lane = Mathf.Clamp(_lane + value, -2, 2)))
            {
                // invokes left event if negative value
                if (value<0)
                {
                    onMoveLeft?.Invoke();
                    Debug.Log("invoke left");
                }
                //invokes right event if positive
                else if (value>0)
                {
                    onMoveRight?.Invoke();
                    Debug.Log("invoke right");
                }
            }
             
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

        //##########
        //Key inputs
        //##########

        if (alive)
        {

            // cheks if player is "grinding" 
            if (!grind && !jump)
            {
                // flags for left movement
                if (Input.GetKeyDown("left"))
                {
                    //Debug.Log("left");
                    //Debug.Log(lane);
                    
                    lane = -1;
                    player.transform.position = new Vector3(lane*2, player.transform.position.y, player.transform.position.z);
                }

                // flags for right movement
                if (Input.GetKeyDown("right"))
                {
                    //Debug.Log("right");
                    //Debug.Log(lane);
                    
                    lane = 1;
                    player.transform.position = new Vector3(lane*2, player.transform.position.y, player.transform.position.z);
                }
            }

            //jump input
            if (Input.GetKeyDown("up"))
            {
                Debug.Log("jump");
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

    //#######
    //Methods
    //#######

    //speed up method
    public void SpeedUp()
    {
        speed += 0.1f;
    }

    //damage method
    public void Oof(int damage)
    {
        //check if health at or lower than 0...
        if (health <= 0)
        {
            speed = 0;
            alive = false;
            onDeath?.Invoke();
        }
        else
        {
            // subtracts damage andinvokes oof...
            health -= damage;
            speed = _baseSpeed;
            onOof?.Invoke();
            
        }

    }

    IEnumerator Jumping()
    {
        jump = true;
        onJunp?.Invoke();
        yield return new WaitForSeconds(0.7f);
        jump = false;
    }

    

}
