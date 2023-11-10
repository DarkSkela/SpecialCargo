using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MineBehaviour : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        //TODO: Check if other is type boat below, now true for testing
        if (true)
        {
            Explode();
        }
    }

    private void Explode()
    {
        //TODO: Add like particle effect or animations here
        
        Destroy(gameObject);
    }
}
