using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 
public class ballscript : MonoBehaviour
{
    public TextMeshProUGUI score1, score2; // bizim ve düþmanýn skor textlerini aldýk 

    public GameObject character1, character2, goalPanel, ball, fallBallSound, netgoalSound, scoregoalsound, strongerwalls1,strongerwalls2;  // gol olduktan sonra lazým olan objeleri aldýk 

    public Transform character1StarterPosition, character2StarterPosition, ballStarterPosition;

    public int score1Value = 0, score2Value = 0; // score deðerlerini tutan integer deðerleri sakladýk 

    public void Update()
    {
        score1.text = "" + score2Value; // score deðerlerini anlýk olarak güncelleyen kod kýsmýdýr 
        score2.text = "" + score1Value; 
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "kale1") // topun kale1 e deðmesi sonucunda olacaklarý tasarladýk 
        {
            StartCoroutine("kale1Controller");
            StartCoroutine("netGoalSoundController");
        }

        if(collision.gameObject.tag == "kale2") // topun kale2 ye deðmesi sonucunda olacaklarý tasarladýk 
        {
            StartCoroutine("kale2Controller"); 
            StartCoroutine("netGoalSoundController"); 
        }

        if(collision.gameObject.tag == "zemin")
        {
            StartCoroutine("fallBallSoundController");
        }
    }

    public IEnumerator fallBallSoundController() // bir numerator olusturarak oluþacak eventleri kontrol ediyoruz
    {
        fallBallSound.SetActive(true);
        yield return new WaitForSeconds(0.3f);
        fallBallSound.SetActive(false); 
    }

    public IEnumerator netGoalSoundController() // bir numerator olusturarak oluþacak eventleri kontrol ediyoruz
    {
        netgoalSound.SetActive(true);
        scoregoalsound.SetActive(true);
        yield return new WaitForSeconds(2.2f);
        netgoalSound.SetActive(false);
        scoregoalsound.SetActive(false);
    }

    public IEnumerator kale1Controller() // bir numerator olusturarak oluþacak eventleri kontrol ediyoruz
    {
        this.gameObject.GetComponent<Rigidbody2D>().mass = 50f; 
        goalPanel.SetActive(true);
        score1Value++;
        strongerwalls1.gameObject.GetComponent<BoxCollider2D>().isTrigger = true; 
        strongerwalls2.gameObject.GetComponent<BoxCollider2D>().isTrigger = true; 
        yield return new WaitForSeconds(1f);
        this.gameObject.GetComponent<Rigidbody2D>().mass = 1f;
        strongerwalls1.gameObject.GetComponent<BoxCollider2D>().isTrigger = false;
        strongerwalls2.gameObject.GetComponent<BoxCollider2D>().isTrigger = false;
        goalPanel.SetActive(false);
        character1.transform.position = character1StarterPosition.position;
        character2.transform.position = character2StarterPosition.position;
        ball.transform.position = ballStarterPosition.position; 
    }

    public IEnumerator kale2Controller() 
    {
        this.gameObject.GetComponent<Rigidbody2D>().mass = 50f;
        goalPanel.SetActive(true);
        score2Value++;
        strongerwalls1.gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
        strongerwalls2.gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
        yield return new WaitForSeconds(1f);
        this.gameObject.GetComponent<Rigidbody2D>().mass = 1f;
        strongerwalls1.gameObject.GetComponent<BoxCollider2D>().isTrigger = false;
        strongerwalls2.gameObject.GetComponent<BoxCollider2D>().isTrigger = false;
        goalPanel.SetActive(false);
        character1.transform.position = character1StarterPosition.position;
        character2.transform.position = character2StarterPosition.position;
        ball.transform.position = ballStarterPosition.position;
    }

}
