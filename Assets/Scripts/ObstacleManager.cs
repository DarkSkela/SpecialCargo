using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleManager : MonoBehaviour
{
    public static ObstacleManager Instance;
    public List<Tuple<GameObject, float>> ObstaclePrefabs;
    public float spawnDelay = 5f;
    private List<GameObject> ObstaclesList;
    private float spawnTimer = 0f;
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Debug.LogError($"Multiple Instances of {gameObject.name} in Scene!");
            Destroy(gameObject);
        }
    }
    void Start()
    {
        ObstaclesList = new List<GameObject>();
        spawnTimer = spawnDelay;
    }

    
    void Update()
    {
       //Spawn obstacles at random intervals
       spawnTimer -= Time.deltaTime;

       if (spawnTimer <= 0f)
       {
           SpawnObstacle();
           spawnTimer = spawnDelay;
       }
       
    }

    void SpawnObstacle()
    {
        throw new NotImplementedException();
    }
}
