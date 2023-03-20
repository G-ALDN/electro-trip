using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public static bool GameIsPaused;

    public GameObject player;

    public GameObject endScreen;

    public GameObject pauseMenu;

    public GameObject _DeathAudio;

    public GameObject _MusicAudio;

    public bool gameOver = false;

    bool _DeathPlaying;

    private void Start()
    {
        _DeathPlaying = false;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (player.GetComponent<PlayerMovement>().isDead)
        {
            gameOver = true;
            if (!_DeathAudio.GetComponent<AudioSource>().isPlaying && !_DeathPlaying)
            {
                _DeathAudio.GetComponent<AudioSource>().Play();
                _MusicAudio.GetComponent<AudioSource>().Pause();
                _DeathPlaying = true;
            }
            endScreen.SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.R) && gameOver)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        if (Input.GetKeyDown(KeyCode.L) && gameOver)
        {
            SceneManager.LoadScene(2);
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseMenu();
        }
    }

    public void PauseMenu()
    {
        if (gameOver)
        {
            return;
        }
        if (GameIsPaused)
        {
            Time.timeScale = 1f;
            pauseMenu.SetActive(false);
            GameIsPaused = false;
        }
        else
        {
            Time.timeScale = 0f;
            pauseMenu.SetActive(true);
            GameIsPaused = true;
        }
    }

    
}

    
