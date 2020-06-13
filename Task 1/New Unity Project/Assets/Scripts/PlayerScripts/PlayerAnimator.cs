using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{

    private Animator anim;
    private ParticleSystem leftBurst;
    private ParticleSystem rightBurst;
    public Material playerTexture;


    private void Start()
    {
        //Event Subscriptions
        PlayerController.instance.onMoveLeft += leftAnim;
        PlayerController.instance.onMoveRight += rightAnim;
        PlayerController.instance.onJunp += jumpAnim;
        PlayerController.instance.onGrindDown += grindOn;
        PlayerController.instance.onGrindUp += grindOff;
        PlayerController.instance.onOof += damageFlash;

        //playerTexture = this.gameObject.GetComponent<Material>();
        anim = this.gameObject.GetComponent<Animator>();
        rightBurst = GameObject.Find("MoveRight").GetComponent<ParticleSystem>();
        leftBurst = GameObject.Find("MoveLeft").GetComponent<ParticleSystem>();
    }

    
    // animator reatctions
    void leftAnim()
    {
        Debug.Log("animating left...");
        leftBurst.Play();
        anim.ResetTrigger("isRight");
        anim.SetTrigger("isLeft");
    }

    void rightAnim()
    {
        Debug.Log("animating right...");
        rightBurst.Play();
        anim.ResetTrigger("isLeft");
        anim.SetTrigger("isRight");
        
    }

    void jumpAnim()
    {
        Debug.Log("animating Jump...");
        anim.SetTrigger("isJumping");
    }
    
    void grindOn()
    {
        Debug.Log("animating GrindDown...");
        anim.SetBool("isGrind", true);
    }

    void grindOff()
    {
        Debug.Log("animating GrindUp...");
        anim.SetBool("isGrind", false);
    }

    void damageFlash()
    {
        StartCoroutine(emmisionFlash());
    }

    IEnumerator emmisionFlash()
    {
        for (int i = 0; i < 3; i++)
        {
            playerTexture.DisableKeyword("_EMISSION");
            yield return new WaitForSecondsRealtime(0.2f);
            playerTexture.EnableKeyword("_EMISSION");
            yield return new WaitForSecondsRealtime(0.1f);
        }
        

    }

}
