using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PowerUpSpawner : MonoBehaviour
{
    public Transform player;
    public GameObject powerUp;
    public Vector3 offset;

    public Transform[] spawnPoints;

    public float spawnBuffer = 2f;
    public float timeToDestroy = 5f;

    private float spawnTime = 2f;


    void Spawn()
    {
        int randomIndex = Random.Range(0, spawnPoints.Length);
        GameObject currentObstacle = null;
        for (int i = 0; i < spawnPoints.Length; i++)
        {
            if (randomIndex == i)
            {
                currentObstacle = Instantiate(powerUp, spawnPoints[i].position, Quaternion.identity);
            }

        }

        Destroy(currentObstacle, timeToDestroy);

    }

    // Update is called once per frame
    void Update()
    {
        if (FindObjectOfType<GameManager>().gameOver)
        {
            enabled = false;
        }
        transform.position = new Vector3(0, player.position.y, player.position.z) + offset;

        if (Time.time >= spawnTime)
        {
            Spawn();
            spawnTime = Time.time + spawnBuffer;

        }



    }
}

