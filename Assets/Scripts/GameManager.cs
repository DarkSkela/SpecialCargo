using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
        
    public GameObject objectToSpawn;
    public Collider collider;
    public GameObject Ship;

    public GameObject startingPoint;

    private bool canSpawn = true;
    private int c = 0;
    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }else
        {
            Destroy(this);
        }
    }

    private void Start()
    {
        StartCoroutine(SpawnAfterTime());
    }

    void SpawnShip()
    {
        Instantiate(Ship, startingPoint.transform.position, startingPoint.transform.rotation);
    }
    IEnumerator SpawnAfterTime()
    {
        while (Application.isPlaying)
        {
            yield return new WaitForSeconds(3);
            SpawnObject(); 
        }
    }
    

    void SpawnObject()
    {
        if (c < 9)
        {
            if (objectToSpawn != null)
            {
                Vector3 spawnPosition = GetRandomPositionInCollider();
                Instantiate(objectToSpawn, spawnPosition, Quaternion.identity);
                c++;
            }
            else
            {
                Debug.LogWarning("Prefab for spawning is not assigned!");
            }
        }
       
    }

    public void DecrementBoxCount()
    {
        if (c > 0)
        {
            c--;
        }
    }

    Vector3 GetRandomPositionInCollider()
    {
         //collider = GetComponent<Collider>();

        if (collider != null)
        {
            // Random position within the collider bounds
            float randomX = Random.Range(collider.bounds.min.x, collider.bounds.max.x);
            float randomY = Random.Range(collider.bounds.min.y, collider.bounds.max.y);
            float randomZ = Random.Range(collider.bounds.min.z, collider.bounds.max.z);

            return new Vector3(randomX, randomY, randomZ);
        }

        // If collider is not found, return zero position
        return Vector3.zero;
    }

}
