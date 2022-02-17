using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyCoins : MonoBehaviour
{
    public GameObject player;

    private float playerZPos;
    private float tunnelZPos;
    // Start is called before the first frame update
    void Start()
    {
        playerZPos = player.transform.position.z;
        tunnelZPos = transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        playerZPos = player.transform.position.z;
        if (playerZPos >= tunnelZPos + 360f)
        {
            Destroy(gameObject);
        }
    }
}
