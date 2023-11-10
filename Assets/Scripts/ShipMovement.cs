using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovement : MonoBehaviour
{
    public float speed = 10f;
    public float rotSpeed = 5f;
    private bool dragging = false;
    Vector3 target = new Vector3(0,0,0f);
    public LayerMask raycastMask;
    
    private bool canMove = false;
    public Transform cargoSlot;
    // Start is called before the first frame update

   // public List<GameObject> coll;

    public Vector2 gridSize = new Vector2(1f, 1f);
    public Transform boxesParent; // Assign the empty GameObject as the parent in the inspector

    private List<Transform> stackedBoxes = new List<Transform>();
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
                if(Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out var hit, Mathf.Infinity, raycastMask))
                {
                    target = hit.point;
                    Vector3 target2D = new Vector3(target.x, 0.0f, target.z);
                    Vector3 distVec = target2D - transform.position;
                    if (true)
                    {
                        Quaternion targetRotation = Quaternion.LookRotation(target2D);
                        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotSpeed * Time.deltaTime);
                    }
                }
            }
            
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
      
    }

    void StackBox(Transform box)
    {
        Vector3 newPosition = CalculateGridPosition();

        box.position = newPosition;
        box.parent = boxesParent;
        //box.GetComponent<Rigidbody>().isKinematic = true;  
        stackedBoxes.Add(box);
    }

    Vector3 CalculateGridPosition()
    {
        int row = stackedBoxes.Count / (int)gridSize.x;
        int col = stackedBoxes.Count % (int)gridSize.x;

        float xOffset = col * gridSize.y;
        float zOffset = row * gridSize.x;

        return new Vector3(boxesParent.position.x + xOffset, boxesParent.position.y, boxesParent.position.z + zOffset);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Cargo"))
        {
            StackBox(other.transform);
        }
        
        if(other.CompareTag("Obstacle"))
        {
            //Do somthing
        }    
    }
}

      
    

