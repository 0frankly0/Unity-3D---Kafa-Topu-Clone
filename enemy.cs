using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    public Transform top; // takip edilecek top
    
    public float hareketHizi = 3f; // takip hýzý
    
    public float temasKuvveti = 40f; // topa temas kuvveti

    private Rigidbody2D rb; // bu nesnenin rigidbody bileþeni

    public Rigidbody2D topRb; 

    public bool floorActivated = false;

    public Animator animEnemy; 

    timecountdown timercountdownSc; 
    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // rigidbody bileþenini al
        timercountdownSc = GameObject.Find("Timermanagement").GetComponent<timecountdown>();
    }
    void FixedUpdate()
    {
        if(floorActivated && timercountdownSc.levelControllerValue > 0 )
        {
            Vector2 hedef = new Vector2(top.position.x + 1f, rb.position.y); // takip edilecek hedef noktasý
            
            Vector2 yon = hedef - rb.position; // takip yönü

            rb.velocity = yon.normalized * hareketHizi; // takip hýzýný ayarla

            float mesafe = Vector2.Distance(rb.position, top.position); // topa olan mesafeyi hesapla

            if (mesafe < 0.5f) // topa temas etti mi?
            {
            rb.AddForce(Vector2.left * temasKuvveti, ForceMode2D.Impulse); // topa doðru kuvvet uygula
            }
        }
    }
    public void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "zemin")
        {
            floorActivated = true;
        }
        
        if (collision.gameObject.tag == "ball")
        {
            topRb.AddForce(Vector2.left * temasKuvveti *Time.deltaTime, ForceMode2D.Impulse); // topa doðru kuvvet uygula
            StartCoroutine("animControllerEnemy");
        }
    }
    public void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "zemin")
        {
            floorActivated = false;
        }
    }

    public IEnumerator animControllerEnemy()
    {
        animEnemy.SetBool("shootenemy", true); 
        yield return new WaitForSeconds(0.2f);
        animEnemy.SetBool("shootenemy", false);
    }
}
