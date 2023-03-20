using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningTrigger : MonoBehaviour
{
    PlayerMovement player;


    

    private void OnTriggerEnter(Collider other)
    {
        player = FindObjectOfType<PlayerMovement>();
        player.ActivateLightning();
        Destroy(gameObject.GetComponentInParent<Transform>().gameObject);

    }
}
