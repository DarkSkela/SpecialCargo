using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cargo : MonoBehaviour
{
    private bool attached = false;
    public LayerMask raycastMask;
    private Vector3 origin;
    // Start is called before the first frame update
    void Start()
    {
        origin = transform.position;
    }

    private void OnMouseDown()
    {
        attached = true;
    }
    private void OnMouseUp()
    {
        if (attached)
        {
            transform.position = origin;
        }

        attached = false;
    }

    private void FixedUpdate()
    {
        if (attached)
        {
            if(Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out var hit, Mathf.Infinity, raycastMask))
            {
                transform.position = hit.point + new Vector3(0, 3f, 0);
            }
        }
    }
    private void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.CompareTag("Ship"))
        {
            gameObject.GetComponent<Rigidbody>().isKinematic = true;
            attached = false;
        }
    }
}
