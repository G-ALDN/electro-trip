using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    public Transform player;
    public TextMeshProUGUI highScoreTMP;
    public TextMeshProUGUI highScoreEndTMP;
    public Color32 highScoreColor;

    TextMeshProUGUI score;

    public float highScore;

    float text;
    // Start is called before the first frame update
    void Start()
    {
        score = GetComponent<TextMeshProUGUI>();
        highScore = PlayerPrefs.GetFloat("High Score", 0);
        highScoreTMP.gameObject.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        text = player.position.z;
        score.text = "Score\n" + text.ToString("0");
        highScoreTMP.text = "Current High Score: " + highScore.ToString("0");


        if (text > PlayerPrefs.GetFloat("High Score", 0))
        {
            highScoreTMP.gameObject.SetActive(true);
            highScore = text;
            PlayerPrefs.SetFloat("High Score", text);
            highScoreEndTMP.color = highScoreColor;
        }

        if (FindObjectOfType<GameManager>().gameOver)
        {
            if (Input.GetKey(KeyCode.Q))
            {
                PlayerPrefs.DeleteAll();
                highScore = 0;
                text = 0;
                score.text = "Score\n0";
                highScoreTMP.text = "Current High Score: 0";
                highScoreEndTMP.color = new Color32(255,255,255,1);
                enabled = false;
            }
            
        }

        highScoreEndTMP.text = "High Score\n" + highScore.ToString("0");
        
    }
}
