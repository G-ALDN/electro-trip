using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LookCamera : MonoBehaviour
{
    public GameObject player;
    public Vector3 offset;

    // Update is called once per frame
    void LateUpdate()
    {
        if (FindObjectOfType<GameManager>().gameOver)
        {
            enabled = false;
        }
        if (player != null)
        {
            transform.position = new Vector3(0f, player.transform.position.y + offset.y, player.transform.position.z + offset.z);
        }
        
        
    }
}
