using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxScript : MonoBehaviour
{

    public GameObject sprite;
    private Vector3 endPos = new Vector3(69.6999969f, 0.50999999f, 0f);
    private Vector3 spriteEndPos = new Vector3(-0.00553999981f, 0.000620000006f, 0.0119500002f);
    private bool play = false;

    // Update is called once per frame
    void Update()
    {
        if (play)
        {
            
            Vector3 dir = endPos - transform.position;
            if (dir.magnitude > 0.1f)
            {
                dir = dir.normalized;
                transform.Translate(dir * 2f * Time.deltaTime, Space.World);
            }
            else
            {
                sprite.transform.localPosition = spriteEndPos;
            }
        }
    }

    public void PlayBox()
    {
        play = true;
    }
}

