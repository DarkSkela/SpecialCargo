using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndScene : MonoBehaviour
{
    public GameObject textA;
    public GameObject textB;
    private int Stage = 0;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            switch (Stage)
            {
                case 0:
                    textA.SetActive(false);
                    textB.SetActive(true);
                    Stage++;
                    break;
                case 1:
                    SceneManager.LoadScene("TitleScreen");
                    break;
                default:
                    break;

            }

        }
    }

}



