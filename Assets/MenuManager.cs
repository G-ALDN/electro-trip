using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{

    AudioSource _as;
    AudioSource[] _asArray;
    public static bool _muted;

    private void Start()
    {
        _as = GetComponent<AudioSource>();
        _asArray = FindObjectsOfType<AudioSource>();
    }
    public void Play()
    {
        _as.Play();
        SceneManager.LoadScene(1);
        GameManager.GameIsPaused = false;
        Time.timeScale = 1f;
        
    }

    public void Menu()
    {
        _as.Play();
        SceneManager.LoadScene(0);
    }

    public void LeaderBoard()
    {
        _as.Play();
        SceneManager.LoadScene(2);
    }
    public void Mute()
    {
        _as.Play();
        MenuManager._muted = !MenuManager._muted;
        for (int i = 0; i < _asArray.Length; i++)
        {
            if (MenuManager._muted)
            {
                _asArray[i].Pause();
            }
            else
            {
                _asArray[i].UnPause();
            }

        }

    }

}
