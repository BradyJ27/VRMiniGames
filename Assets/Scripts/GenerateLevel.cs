using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateLevel : MonoBehaviour
{
    public GameObject tunnel;
    public GameObject collectable;
    private float zPos;

    // Start is called before the first frame update
    void Start()
    {
        zPos = 50;
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.z >= zPos - 25)
		{
            zPos += 50;
            tunnel = Instantiate(tunnel, new Vector3(0, 0, zPos), Quaternion.identity);
            tunnel.gameObject.name = "Tunnel";
            Instantiate(collectable, new Vector3(0, 5, zPos), Quaternion.identity);
        }
    }

    void OnTriggerExit(Collider other)
    {
        Destroy(other.gameObject.transform.parent.gameObject);
    }
}
