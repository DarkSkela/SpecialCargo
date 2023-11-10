using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cargo : MonoBehaviour
{
    private bool attached = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnMouseDown()
    {
        attached = true;
    }
    private void OnMouseUp()
    {
        attached = false;
    }

    private void FixedUpdate()
    {
        if (attached)
        {
            transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 20.0f));
        }
    }
    //private void OnCollisionEnter(Collision collision)
    //{
    //    if(collision.gameObject.CompareTag("Ship"))
    //    {
    //        transform.position = GameManager.Instance.Ship.transform.position + new Vector3(0,1f,0);

    //    }
    //}
}
