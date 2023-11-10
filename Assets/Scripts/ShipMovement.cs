using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovement : MonoBehaviour
{
    public float speed = 10f;
    public float rotSpeed = 5f;
    private bool dragging = false;
    Vector3 target = new Vector3(0,0,0f);
    
    private bool canMove = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnMouseDown()
    {
        if (!canMove)
        {
            canMove = true;
        }
        dragging = true;
    }

    private void OnMouseUp()
    {
        dragging = false;
    }
    // Update is called once per frame
    void Update()
    {
        if(canMove)
        {
            if (dragging)
            {
                target = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.nearClipPlane));
                Vector3 target2D = new Vector3(target.x, 0.0f, target.z);
                Vector3 distVec = target2D - transform.position;
                if (distVec.magnitude > 1)
                {
                    Quaternion targetRotation = Quaternion.LookRotation(target2D);
                    transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotSpeed * Time.deltaTime);
                }
            }
            
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
      
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Obstacle"))
        {
            //Do somthing
        }    
    }
}
