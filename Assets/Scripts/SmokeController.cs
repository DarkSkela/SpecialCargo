using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class SmokeController : MonoBehaviour
{
    public VisualEffect fx;
    public Animator anim;
    public BoxScript box;

    private GameObject Ship;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(StrikeLightning());
    }

    private void Update()
    {
        if (Ship != null)
        {
            transform.position = Ship.transform.position;
            Ship.transform.Translate(0f, -5f *Time.deltaTime, 0f);
            Ship.transform.Rotate(new Vector3(15f * Time.deltaTime, 0f, 0f ));
        }
    }

    IEnumerator StrikeLightning()
    {
        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.K));
        anim.SetTrigger("Strike");
        yield return new WaitForSeconds(1.25f);
        fx.Play();
        Ship = GameObject.FindGameObjectWithTag("Ship");
        yield return new WaitForSeconds(3f);
        Ship.gameObject.GetComponent<MeshRenderer>().enabled = false;
        box.PlayBox();
    }
}
