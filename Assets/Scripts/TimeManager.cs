using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    public float slowDownFactor = 0.05f;
    public float slowDownLength = 2f;
    public float zoomOutTime = 20f;
    public float zoomInFOV = 50f;

    Camera mainCamera;
    private void Start()
    {
        mainCamera = FindObjectOfType<Camera>();
    }

    private void Update()
    {
        if (!GameManager.GameIsPaused)
        {
            Time.timeScale += (1f / slowDownLength) * Time.unscaledDeltaTime;
            Time.timeScale = Mathf.Clamp(Time.timeScale, 0f, 1f);

            mainCamera.fieldOfView += zoomOutTime * Time.unscaledDeltaTime;

            mainCamera.fieldOfView = Mathf.Clamp(mainCamera.fieldOfView, 0f, 60f);
        }







    }

    
        
    
    
    public void ObstacleBreak()
    {
        Time.timeScale = slowDownFactor;
        mainCamera.fieldOfView = zoomInFOV;
        //Time.fixedDeltaTime = Time.timeScale * .02f;


    }
}
