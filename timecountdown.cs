using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro; 


public class timecountdown : MonoBehaviour
{
    public float countFrom = 10f; // Geriye say�m�n ba�layaca�� say�
    public TextMeshProUGUI countdownText, starterCountDownText; // Text nesnesi, geriye say�m� yazd�rmak i�in kullan�l�r
    private float timeLeft; // Geriye kalan s�reyi takip etmek i�in kullan�l�r
    public GameObject starterTimerValue;
    public float levelControllerValue = 0f; // Timer de�erinin ikinci defa s�f�r� bulmas� durumunda eventleri kontrol edecek olan value de�eridir.
    private void Start()
    {
        timeLeft = countFrom;
        countdownText.color = Color.red; 
        starterCountDownText.color = Color.green;
        starterTimerValue.SetActive(true); 
    }
    private void Update()
    {
        // Geriye say�m�n yap�lmas� ve text nesnesine yazd�r�lmas�
        timeLeft -= Time.deltaTime;
        int countdownInt = Mathf.RoundToInt(timeLeft);
        countdownText.text = "0 : " +  countdownInt.ToString();
        starterCountDownText.text =  countdownInt.ToString();
        // Geriye say�m tamamland���nda, i�lemleri durdur
        if (countdownInt <= 0)
        {
            timeLeft = 60;
            countdownText.color = Color.black;
            starterTimerValue.SetActive(false);
            levelControllerValue++; 
        }
    }
}
