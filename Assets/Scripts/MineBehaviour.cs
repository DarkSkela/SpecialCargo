using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MineBehaviour : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Ship"))
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
