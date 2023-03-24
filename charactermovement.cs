using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class charactermovement : MonoBehaviour
{

    // karakterin hareket kodlarýný barýndýrýr 

    public bool moveRight = false, moveLeft = false, isJumping = false;

    public float speed = 2f;

    Rigidbody2D rig; 

    timecountdown timerCdSc;
    public void Start()
    {
        timerCdSc = GameObject.Find("Timermanagement").GetComponent<timecountdown>();
        rig = gameObject.GetComponent<Rigidbody2D>();
    }
    public void FixedUpdate()
    {
        if(moveRight && timerCdSc.levelControllerValue > 0 )
        {
            transform.Translate(speed * Time.deltaTime, 0f, 0f); 
        }
        if(moveLeft && timerCdSc.levelControllerValue > 0)
        {
            transform.Translate(-speed * Time.deltaTime, 0f, 0f);
        }
    }
    public void jumpButton()
    {
        if(isJumping)
        {
            rig.AddForce(new Vector2(0f, 350f));
        }
    }
    public void moveRightOn()
    {
        moveRight = true; 
    }
    public void moveRightOff()
    {
        moveRight = false; 
    }
    public void moveLeftOn()
    {
        moveLeft = true; 
    }
    public void moveLeftOff()
    {
        moveLeft = false; 
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "zemin")
        {
            isJumping = true; 
        }
    }
    public void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "zemin")
        {
            isJumping = false;
        }
    }
}
