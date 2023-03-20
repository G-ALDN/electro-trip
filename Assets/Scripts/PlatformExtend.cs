using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlatformExtend : MonoBehaviour
{
    public Transform player;
    public GameObject platform;
    

    Vector3 newPosition;

    GameObject oldPlatform;

    public bool isSpawned;
    

    // Update is called once per frame
    void Update()
    {
        if (FindObjectOfType<GameManager>().gameOver)
        {
            enabled = false;
        }
        Extend();
        isSpawned = false;
        

    }

    void Extend()
    {

        
        newPosition = new Vector3(platform.transform.position.x, platform.transform.position.y, platform.transform.position.z + 100f);
        

        if (platform != null)
        {
            oldPlatform = platform;
        }

        if (player.position.z >= oldPlatform.transform.position.z + 90f && !isSpawned)
        {
            GameObject newPlatform = Instantiate(oldPlatform, newPosition, Quaternion.identity);
            isSpawned = true;
            newPlatform.name = "Platform";
            platform = newPlatform;
            Destroy(oldPlatform, 10f);
            FindObjectOfType<PlayerMovement>().IncreaseSpeed();
        }
        
    }
}
