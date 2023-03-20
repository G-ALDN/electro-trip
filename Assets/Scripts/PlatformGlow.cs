using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGlow : MonoBehaviour
{
    public Transform playerPosition;
    public int index;
    public Material glowMaterial;


    Animator animator;

    
    PlayerMovement pm;


    private void Start()
    {

        animator = transform.GetComponentInChildren<Animator>();

        pm = FindObjectOfType<PlayerMovement>();
        
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (pm != null && playerPosition != null)
        {
            if (pm.isLeft)
            {
                index = 0;
            }
            else if (pm.isRight)
            {
                index = 2;
            }
            else
            {
                index = 1;
            }

            if (playerPosition.position.x != transform.position.x)
            {
                
                Glow();
            }
        }
    }

    private void Glow()
    {
        
        if (animator != null)
        {
            animator.SetBool("OnPlatform", false);
        }
        


        int i = 0;
        foreach (Transform plat in transform)
        {
            if (index == i)
            {
                animator = plat.GetComponent<Animator>();
                animator.SetBool("OnPlatform", true);
                if (FindObjectOfType<GameManager>().gameOver)
                {
                    animator.SetBool("OnPlatform", false);
                }



            }
            
            i++;
        }
        
    }
 
}
