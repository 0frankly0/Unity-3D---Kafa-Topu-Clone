using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro; 


public class timecountdown : MonoBehaviour
{
    public float countFrom = 10f; // Geriye sayýmýn baþlayacaðý sayý
    public TextMeshProUGUI countdownText, starterCountDownText; // Text nesnesi, geriye sayýmý yazdýrmak için kullanýlýr
    private float timeLeft; // Geriye kalan süreyi takip etmek için kullanýlýr
    public GameObject starterTimerValue;
    public float levelControllerValue = 0f; // Timer deðerinin ikinci defa sýfýrý bulmasý durumunda eventleri kontrol edecek olan value deðeridir.
    private void Start()
    {
        timeLeft = countFrom;
        countdownText.color = Color.red; 
        starterCountDownText.color = Color.green;
        starterTimerValue.SetActive(true); 
    }
    private void Update()
    {
        // Geriye sayýmýn yapýlmasý ve text nesnesine yazdýrýlmasý
        timeLeft -= Time.deltaTime;
        int countdownInt = Mathf.RoundToInt(timeLeft);
        countdownText.text = "0 : " +  countdownInt.ToString();
        starterCountDownText.text =  countdownInt.ToString();
        // Geriye sayým tamamlandýðýnda, iþlemleri durdur
        if (countdownInt <= 0)
        {
            timeLeft = 60;
            countdownText.color = Color.black;
            starterTimerValue.SetActive(false);
            levelControllerValue++; 
        }
    }
}
