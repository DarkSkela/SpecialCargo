using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PatrolBoatBehaviour : MonoBehaviour
{
    public List<Vector3> patrolPoints;

    public float speed = 5f;

    public float rotationSpeed = 5f;

    private Queue<Vector3> pointQueue;
    
    private Vector3 currentPatrolPoint;

    private GameObject Model;
    // Start is called before the first frame update
    void Start()
    {
        pointQueue = new Queue<Vector3>();
        FillQueue();
        currentPatrolPoint = pointQueue.Dequeue();
        Model = transform.GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 dir = currentPatrolPoint - transform.position;
        float dist = dir.magnitude;
        Vector3 moveDir = dir.normalized;
        Quaternion rotation = Quaternion.LookRotation(dir);
        Model.transform.rotation = Quaternion.Slerp(Model.transform.rotation, rotation, Time.deltaTime * rotationSpeed);
        if (dist > 0.1f)
        {
            transform.Translate(moveDir * (speed * Time.deltaTime));
        }
        else
        {
            currentPatrolPoint = pointQueue.Dequeue();
            if (pointQueue.Count == 0)
            {
                FillQueue();
            }
        }
    }

    private void FillQueue()
    {
        foreach (var p in patrolPoints)
        {
            pointQueue.Enqueue(p);
        }
    }
}
