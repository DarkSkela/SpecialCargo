using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovement : MonoBehaviour
{
    public float speed = 10f;
    public float rotSpeed = 5f;
    private bool dragging = false;
    Vector3 target = new Vector3(0, 0, 0f);
    public LayerMask raycastMask;

    private bool canMove = false;
    // Start is called before the first frame update

    // public List<GameObject> coll;

    public Vector2 gridSize = new Vector2(1f, 1f);
    public Transform boxesParent; // Assign the empty GameObject as the parent in the inspector

    private List<Transform> stackedBoxes = new List<Transform>();
    private List<Vector3> boxPositions = new List<Vector3>();


    void Start()
    {
        for (int i = 0; i < gridSize.x; i++)
        {
            for (int j = 0; j < gridSize.y; j++)
            {
                boxPositions.Add(new Vector3(boxesParent.position.x + i, boxesParent.position.y, boxesParent.position.z + j));
            }
        }
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
        if (canMove)
        {
            if (dragging)
            {
                if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out var hit, Mathf.Infinity, raycastMask))
                {
                    target = hit.point;
                    Debug.DrawLine(transform.position, hit.point, Color.red);
                    Vector3 target2D = new Vector3(target.x, 0.0f, target.z);
                    Vector3 distVec = target2D - transform.position;
                    Vector3 dir = distVec.normalized;
                    if (true)
                    {
                        Quaternion lookRot = Quaternion.LookRotation(dir);
                        transform.rotation = Quaternion.Slerp(transform.rotation, lookRot, rotSpeed * Time.deltaTime);
                        transform.localEulerAngles = new Vector3(0f, transform.localEulerAngles.y, 0f);
                    }
                }
            }

            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }

    }

    void StackBox(Transform box)
    {
        if (!stackedBoxes.Contains(box) && stackedBoxes.Count < (gridSize.x * gridSize.y))
        {
            Vector3 newPosition = CalculateGridPosition(stackedBoxes.Count);

            box.parent = boxesParent;
            box.position = newPosition;
            //box.GetComponent<Rigidbody>().isKinematic = true;
            stackedBoxes.Add(box);
        }
    }

    Vector3 CalculateGridPosition(int index)
    {
        return boxPositions[index];
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Cargo"))
        {
            StackBox(other.transform);
        }
        
        if(other.CompareTag("Obstacle"))
        {
           
        }
        if (other.CompareTag("Island"))
        {
            UIManager.Instance.UpdateMoneyAmount((stackedBoxes == null? 0: stackedBoxes.Count) * 10);
            //transform.position = new Vector3(transform.position.x, transform.position.y,other.contactOffset);
            canMove = false;
        }
    }

}

      
    

