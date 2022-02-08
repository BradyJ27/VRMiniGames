using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float zNew;
    // Start is called before the first frame update
    void Start()
    {
        zNew = transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        zNew += 0.01f;
        transform.position = new Vector3(0,0, zNew);
    }

   
}
