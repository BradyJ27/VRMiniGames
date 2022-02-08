using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrapplePhysics : MonoBehaviour
{
    //public GameObject hand;
    private GameObject hand;
    private Vector3 handStartPos;
    // Start is called before the first frame update
    void Start()
    {
        //handStartPos = hand.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        Ray raycast = new Ray(transform.position, transform.forward);
        Debug.DrawRay(transform.position, transform.forward, Color.green);
        if (Physics.Raycast(raycast, out hit))
        {
            Debug.Log("hit");
        }
    }
}
