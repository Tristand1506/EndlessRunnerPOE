using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    int lives;
    public Animator playerAnim;
    public GameObject player;
    
    public ParticleSystem strafeBlastR;
    public ParticleSystem strafeBlastL;
    public TrailRenderer neonTrail;
    public Camera mainCamera;
    public float speed;
    private bool alive;
    int lane;
    

    // Start is called before the first frame update
    void Start()
    {
        alive = true;

        lives = 3;

       player = Object.Instantiate(player, new Vector3(0, 1, 5), Quaternion.Euler(-90,0,0));
        player.transform.SetParent(this.transform);
        playerAnim = player.transform.GetChild(0).GetComponent<Animator>();
        neonTrail = player.transform.GetChild(0).GetChild(1).GetComponent<TrailRenderer>();
        strafeBlastR = player.transform.GetChild(1).GetComponent<ParticleSystem>();
        strafeBlastL = player.transform.GetChild(2).GetComponent<ParticleSystem>();

        lane = 0;
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Translate(Vector3.forward*Time.deltaTime*speed);
        playerAnim.SetBool("Left", false);
        playerAnim.SetBool("Right", false);

        if (alive)
        {



            if (player.transform.GetChild(0).position.y <= 2.5)
            {
                playerAnim.SetBool("Jump", false);
            }


            if (Input.GetKeyDown("left") && !playerAnim.GetBool("Grind"))
            {
                if (lane != Mathf.Clamp(lane - 1, -2, 2))
                {
                    lane = Mathf.Clamp(lane - 1, -2, 2);
                    playerAnim.SetBool("Left", true);
                    strafeBlastL.Play();
                    player.transform.Translate(Vector3.left * 2);

                }

            }
            if (Input.GetKeyDown("right") && !playerAnim.GetBool("Grind"))
            {
                if (lane != Mathf.Clamp(lane + 1, -2, 2))
                {

                    lane = Mathf.Clamp(lane + 1, -2, 2);
                    strafeBlastR.Play();
                    playerAnim.SetBool("Right", true);
                    player.transform.Translate(Vector3.right * 2);

                }
            }

            if (Input.GetKeyDown("up") && playerAnim.GetBool("Jump") == false)
            {

                //Debug.Log("jump");
                playerAnim.SetBool("Jump", true);
            }


            if (Input.GetKeyUp("down"))
            {

                //Debug.Log("SlamminOFF");
                playerAnim.SetBool("Grind", false);
                neonTrail.emitting = true;

            }

            if (Input.GetKeyDown("down"))
            {

                //Debug.Log("Slammin!!!");
                playerAnim.SetBool("Grind", true);
                neonTrail.emitting = false;

            }
            if (Input.GetKeyUp("down"))
            {

                //Debug.Log("SlamminOFF");
                playerAnim.SetBool("Grind", false);
                neonTrail.emitting = true;

            }


        }

    }

    public void LoseLife()
    {
        if (lives>0)
        {
            lives -= 1;
        }
        
        if (lives <= 0)
        {
            speed = 0;
            alive = false;
        }
        
        Debug.Log("Lives: " + lives);

    }
    public int GetLives()
    {
        return lives;
    }

}
