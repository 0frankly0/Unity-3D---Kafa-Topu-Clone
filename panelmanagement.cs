using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class panelmanagement : MonoBehaviour
{

    // main menude ki panel kontrollerini saðlarýz 

    public GameObject loadpanel, slotEnemy, finderText, findText, scoreenemyText;  
    void Start()
    {
        loadpanel.SetActive(false);
        slotEnemy.SetActive(false);
        findText.SetActive(false);
        scoreenemyText.SetActive(false); 
    }
    public void gameButton()
    {
        StartCoroutine("loadCourotineFirst");
    }
    public IEnumerator loadCourotineFirst()
    {
        loadpanel.SetActive(true);
        slotEnemy.SetActive(false);
        findText.SetActive(false);
        scoreenemyText.SetActive(false);
        yield return new WaitForSeconds(3f);
        slotEnemy.SetActive(true);
        finderText.SetActive(false); 
        findText.SetActive(true);
        scoreenemyText.SetActive(true);
        StartCoroutine("loadCourotineSecond");
    }
    public IEnumerator loadCourotineSecond()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(2);
    }
}
