using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HighScore : MonoBehaviour
{
    TextMeshProUGUI highScoreText;
    
    // Start is called before the first frame update
    void Start()
    {
        highScoreText = GetComponent<TextMeshProUGUI>();

    }

    // Update is called once per frame
    void Update()
    {
        highScoreText.text = "Current High Score: " + PlayerPrefs.GetFloat("High Score", 0f).ToString("0");

    }
}
