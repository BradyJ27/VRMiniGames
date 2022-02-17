using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateLevel : MonoBehaviour
{
    public GameObject tunnel;
    public GameObject collectable;
    private float zPos;
    private float xPos;
    private float yPos;

    // Start is called before the first frame update
    void Start()
    {
        zPos = 60;
        xPos = 30;
        yPos = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.z >= zPos - 180)
		{
            zPos += 60;
            tunnel = Instantiate(tunnel, new Vector3(xPos, yPos, zPos), Quaternion.identity);
            tunnel.gameObject.name = "Tunnel";
            Instantiate(collectable, new Vector3(0, 5, zPos), Quaternion.identity);
        }
    }
}
