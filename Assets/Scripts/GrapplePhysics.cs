using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrapplePhysics : MonoBehaviour
{
    //public GameObject hand;
    private GameObject hand;
    private Vector3 handStartPos;
    public Transform camera;
    // Start is called before the first frame update
    void Start()
    {
        //handStartPos = hand.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        Ray raycast = new Ray(camera.position, camera.forward);
        Debug.DrawRay(camera.position, camera.forward, Color.green);
        if (Physics.Raycast(raycast, out hit))
        {
            Debug.Log("hit");
            //Debug.Log(transform.position);
            
        }
    }
}
