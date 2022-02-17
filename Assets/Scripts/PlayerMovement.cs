using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public GameObject textBox;
    private float zNew;
    private float yPos;
    // Start is called before the first frame update
    void Start()
    {
        zNew = transform.position.z;
        yPos = transform.position.y;
        textBox.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(zNew <= 3.5)
        {
            zNew += 0.01f;
            transform.position = new Vector3(0, yPos, zNew);
        }

        if(zNew >= 3.5)
        {
            textBox.SetActive(true);
        }
        
    }

   
}
