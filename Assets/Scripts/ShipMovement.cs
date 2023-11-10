using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovement : MonoBehaviour
{
    public float speed = 10f;
    public float rotSpeed = 5f;
    private bool dragging = false;
    private Vector3 offset;
    Rigidbody rb;

    float drag = 2f;
    float angularDrag = 5f;
    Vector3 pos = new Vector3(0,0,1f);

    public Transform cube;
    [SerializeField]
    private bool canMove = false;
    public Transform cargoSlot;
    // Start is called before the first frame update

   // public List<GameObject> coll;

    public Vector2 gridSize = new Vector2(1f, 1f);
    public Transform boxesParent; // Assign the empty GameObject as the parent in the inspector

    private List<Transform> stackedBoxes = new List<Transform>();
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.drag = drag;
        rb.angularDrag = angularDrag;
    }
    private void OnMouseDown()
    {
        dragging = true;
        offset = transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10.0f));
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
    }

    private void OnMouseUp()
    {
        dragging = false;
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if(canMove)
        {
            if (dragging)
            {
                // transform.LookAt(new Vector3( Input.mousePosition.x, 0, Input.mousePosition.y));
                pos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10.0f)) + offset;
                // rb.MovePosition(new Vector3(pos.x, transform.position.y, pos.z));
                rb.AddForce(new Vector3(pos.x, 0, pos.z) * speed * Time.deltaTime);
                // var p = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10.0f));
                //cube.LookAt(new Vector3(p.x, 0, p.z));


            }
            rb.AddForce(pos);
            Quaternion targetRotation = Quaternion.LookRotation(pos);
            cube.rotation = Quaternion.Slerp(cube.rotation, targetRotation, rotSpeed * Time.deltaTime);
        }
      
    }
    void SnapToCargoSlot()
    {
       
        
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
    }
}

      
    

