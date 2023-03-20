using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerMovement : MonoBehaviour
{
    public GameObject boom;
    public GameObject obstacleBoom;
    public GameObject lightning;
    public GameObject trail;
    public GameObject _SwitchAudio;
    public GameObject _CrashAudio;
    public GameObject _Boosters;

    public TimeManager timeManager;



    public float constantSpeed = 10f;
    public float rotateSpeed = 100f;
    public float duration = 5f;

    public bool isLeft = false;
    public bool isRight = false;


    
    public bool isDead = false;

    bool lightningOn = false;
    
    float returnSpeed = 10f;


    // Update is called once per frame
    void Update()
    {
        


        transform.position += new Vector3(0f, 0f, constantSpeed * Time.deltaTime);
        transform.Rotate(new Vector3(0, rotateSpeed, 0) * Time.deltaTime);

        if ((Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D)) && !isRight)
        {
            _SwitchAudio.GetComponent<AudioSource>().Play();
            transform.position += new Vector3(1.0f, 0, 0);
            

            if (isLeft)
            {
                isLeft = false;
                


            }
            else
            {
               
                isRight = true;
            }
        }
        if ((Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A)) && !isLeft)
        {
            _SwitchAudio.GetComponent<AudioSource>().Play();
            transform.position += new Vector3(-1.0f, 0, 0);
            

            if (isRight)
            {
                isRight = false;

            }
            else
            {
                
                isLeft = true;
            }
        }

        if (!lightningOn)
        {
            returnSpeed = constantSpeed;
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            if (lightningOn)
            {
                Instantiate(obstacleBoom, collision.gameObject.transform.position + new Vector3(0f, 0f, 2f), Quaternion.identity);
                _CrashAudio.GetComponent<AudioSource>().Play();
                timeManager.ObstacleBreak();
                Destroy(collision.gameObject);

            }
            else
            {
                isDead = true;
                gameObject.SetActive(false);
                Instantiate(boom, gameObject.transform.position, Quaternion.identity);
            }
            
            
        }
    }

    public void IncreaseSpeed() 
    {
        
        constantSpeed *= 1.075f;
        rotateSpeed += 1.075f;

        
    }

    


    public void ActivateLightning()
    {
        _Boosters.SetActive(true);
        lightningOn = true;
        lightning.SetActive(true);
        trail.SetActive(true);
        constantSpeed *= 5f;

        Invoke("DeactivateLightning", duration);
        
    }
    public void DeactivateLightning()
    {
        _Boosters.SetActive(false);
        lightningOn = false;
        lightning.SetActive(false);
        trail.SetActive(false);
        constantSpeed = returnSpeed;

    }






}
