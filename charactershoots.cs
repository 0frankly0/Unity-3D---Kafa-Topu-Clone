using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class charactershoots : MonoBehaviour
{

    // þut olaylarý için gerekli kontrolleri tanýmladým 

    public Rigidbody2D ballRigidbody;

    public bool ballÝsActivited = false;

    public Animator animShoes;

    public GameObject kickBallSound; 

    public void OnTriggerStay2D(Collider2D other) // topun radar alaný içinde olup olmadýðýný kontrol eder 
    {
        if (other.gameObject.tag == "ball")
        {
            ballÝsActivited = true;
        }
    }
    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "ball")
        {
            ballÝsActivited = false;
        }
    }

    public void forwardShoot() // Ýleriye doðru þut çekmek için yazdým 
    {
        if(ballÝsActivited)
        {
            ballRigidbody.AddForce(new Vector2(150f, 0f));
            StartCoroutine("kickBallSoundController");
        }
        StartCoroutine("animatorShoes");
    }
    public void upperShoot() // Havaya doðru þut çekmek için yazdým 
    {
        if (ballÝsActivited)
        {
            ballRigidbody.AddForce(new Vector2(120f, 90f));
            StartCoroutine("kickBallSoundController");
        }
        StartCoroutine("animatorShoes");
    }
    public IEnumerator animatorShoes()
    {
        animShoes.SetBool("shoot", true); 
        yield return new WaitForSeconds(0.2f);
        animShoes.SetBool("shoot", false);
    }
    public IEnumerator kickBallSoundController() // Bir numerator olusturarak oluþacak eventleri kontrol ediyoruz
    {
        kickBallSound.SetActive(true);
        yield return new WaitForSeconds(0.3f);
        kickBallSound.SetActive(false);
    }
}
