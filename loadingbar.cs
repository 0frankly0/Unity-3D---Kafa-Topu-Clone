using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class loadingbar : MonoBehaviour
{
    // ba�lang��taki loading scene kontrol eder 
   public void loadingBarFinish()
    {
        SceneManager.LoadScene(1);
    }
}

