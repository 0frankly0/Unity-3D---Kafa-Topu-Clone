using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class charactershoots : MonoBehaviour
{

    // �ut olaylar� i�in gerekli kontrolleri tan�mlad�m 

    public Rigidbody2D ballRigidbody;

    public bool ball�sActivited = false;

    public Animator animShoes;

    public GameObject kickBallSound; 

    public void OnTriggerStay2D(Collider2D other) // topun radar alan� i�inde olup olmad���n� kontrol eder 
    {
        if (other.gameObject.tag == "ball")
        {
            ball�sActivited = true;
        }
    }
    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "ball")
        {
            ball�sActivited = false;
        }
    }

    public void forwardShoot() // �leriye do�ru �ut �ekmek i�in yazd�m 
    {
        if(ball�sActivited)
        {
            ballRigidbody.AddForce(new Vector2(150f, 0f));
            StartCoroutine("kickBallSoundController");
        }
        StartCoroutine("animatorShoes");
    }
    public void upperShoot() // Havaya do�ru �ut �ekmek i�in yazd�m 
    {
        if (ball�sActivited)
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
    public IEnumerator kickBallSoundController() // Bir numerator olusturarak olu�acak eventleri kontrol ediyoruz
    {
        kickBallSound.SetActive(true);
        yield return new WaitForSeconds(0.3f);
        kickBallSound.SetActive(false);
    }
}
