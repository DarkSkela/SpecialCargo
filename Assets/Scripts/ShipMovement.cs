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
    //public Transform cargoSlot;
    // Start is called before the first frame update
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
    //void SnapToCargoSlot()
    //{
    //    Collider[] hitColliders = Physics.OverlapSphere(cargoSlot.position, 2.0f);
    //    foreach (Collider col in hitColliders)
    //    {
    //        if (col.CompareTag("Cargo"))
    //        {
    //            col.transform.position += cargoSlot.position;
    //           // col.transform.parent = cargoSlot;

    //        }
    //    }
    //}
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Cargo"))
        {
            // collision.transform.position = transform.position + new Vector3(0, 1f, 0);
            //SnapToCargoSlot();
        }    
    }
}
