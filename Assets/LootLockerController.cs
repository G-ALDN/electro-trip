using UnityEngine.UI;
using LootLocker.Requests;
using UnityEngine;
using TMPro;
using System.Collections;

public class LootLockerController : MonoBehaviour
{
    public TMP_InputField MemberName;
    public int ID;
    public TextMeshProUGUI[] NameEntries;
    public TextMeshProUGUI[] ScoreEntries;
    public TextMeshProUGUI CharLimitText;
    public Animator LDAnimator;
    public Animator TitleAnimator;
    public Animator ShowButtonAnimator;
    public Animator CharLimitAnimator;
    public AudioSource _as;

    float RawPlayerScore;

    int PlayerScore;
    int MaxScores = 10;

    private void Start()
    {
        _as = GetComponent<AudioSource>();
        RawPlayerScore = PlayerPrefs.GetFloat("High Score", 0);
        PlayerScore = int.Parse(RawPlayerScore.ToString("0"));
        StartCoroutine(LoginRoutine());
        
            
    }

    IEnumerator LoginRoutine()
    {

        bool done = false;
        LootLockerSDKManager.StartGuestSession((response) =>
        {
            if (response.success)
            {
                Debug.Log("Success");
                PlayerPrefs.SetString("PlayerID", response.player_id.ToString());
                done = true;
            }
            else
            {
                Debug.Log("Failed");
                done = true;
            }
            
        });
        yield return new WaitWhile(() => done == false);
    }

    public void ShowScores()
    {
        _as.Play();
        LDAnimator.SetBool("TriggerLD", true);
        TitleAnimator.SetBool("TriggerLD", true);
        ShowButtonAnimator.SetBool("TriggerLD", true);
        LootLockerSDKManager.GetScoreList(ID, MaxScores, (response) =>
        {
            if(response.success)
            {
                LootLockerLeaderboardMember[] scores = response.items;

                for (int i = 0; i < scores.Length; i++)
                {
                    NameEntries[i].text = scores[i].rank + ".   " + scores[i].member_id;
                    ScoreEntries[i].text = scores[i].score.ToString();
                }

                if(scores.Length < MaxScores)
                {
                    for(int i = scores.Length; i < MaxScores; i++)
                    {
                        NameEntries[i].text = (i + 1).ToString() + ".   No Data";
                        ScoreEntries[i].text = "No Data";
                    }
                }
            }
            else
            {
                Debug.Log("Failed" + response.Error);
            }
        });
    }

    public void SubmitScore()
    {
        _as.Play();
        if (MemberName.text.Length > 10)
        {
            CharLimitAnimator.Play("Char Limit");
            CharLimitText.text = "< 10 characters";
        }
        else
        {
            StartCoroutine(SubmitScoreRoutine());
            CharLimitText.text = "Success!!";
            CharLimitAnimator.Play("Char Limit Success");
        }
        
    }


       IEnumerator SubmitScoreRoutine()
    {
        bool done = false;
        string playerID = PlayerPrefs.GetString("PlayerID");
        LootLockerSDKManager.SubmitScore(MemberName.text, PlayerScore, ID, (response) =>
        {
            if (response.success)
            {
                Debug.Log("Success");
                done = true;
            }
            else
            {
                Debug.Log("Failed" + response.Error);
                done = true;
            }
        });
        yield return new WaitWhile(() => done == false);
    }
}
