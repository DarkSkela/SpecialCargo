using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuickSceneChanger : MonoBehaviour
{
   public void LoadSceneOne()
    {
        SceneManager.LoadScene("Base Gameplay");

    }

    public void LoadSceneTwo()
    {
        SceneManager.LoadScene("Crash");

    }

    public void LoadSceneThree()
    {
        SceneManager.LoadScene("Endgame");

    }
}
