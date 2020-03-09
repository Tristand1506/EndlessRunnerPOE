using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public Animator playerAnim;
    public GameObject player;
    public ParticleSystem sparks;
    public Camera mainCamera;
    public float speed;
    int lane;

    // Start is called before the first frame update
    void Start()
    {
        
       player = Object.Instantiate(player, new Vector3(0, 1, 5), Quaternion.Euler(-90,0,0));
        player.transform.SetParent(this.transform);
        playerAnim = player.transform.GetChild(0).GetComponent<Animator>();

        lane = 0;
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Translate(Vector3.forward*Time.deltaTime*speed);

        if (Input.GetKeyDown("left") && !playerAnim.GetBool("Grind"))
        {
            if (lane != Mathf.Clamp(lane - 1, -2, 2))
            {
                lane = Mathf.Clamp(lane - 1, -2, 2);
                player.transform.Translate(Vector3.left * 2);
            }
            
        }
        if (Input.GetKeyDown("right")&&!playerAnim.GetBool("Grind"))
        {
            if (lane != Mathf.Clamp(lane + 1, -2, 2))
            {
                lane = Mathf.Clamp(lane + 1, -2, 2);
                player.transform.Translate(Vector3.right * 2);
            }
        }
        if (Input.GetKeyDown("down"))
        {

            Debug.Log("Slammin!!!");
            playerAnim.SetBool("Grind",true);

        }
        if (Input.GetKeyUp("down"))
        {

            Debug.Log("SlamminOFF");
            playerAnim.SetBool("Grind", false);

        }




    }
}
