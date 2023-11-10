using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BoxSpawnBehaviour : MonoBehaviour
{
    private void OnTriggerExit(Collider other)
    {
        if (other.tag.Equals("Cargo"))
        {
            GameManager.Instance.DecrementBoxCount();
        }
    }
}
