using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public Animator anim;
  public void StartGame()
    {
        Debug.Log("Game Start");
        anim.SetTrigger("Play");

    }

    public void LoadGame(AnimationEvent e)
    {
        SceneManager.LoadScene("Game");
        Debug.Log("Scene Loaded");
    }

    public void QuitGame()
    {
        Debug.Log("Game Closed");
        Application.Quit();

    }
}
