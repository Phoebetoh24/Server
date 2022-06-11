using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using PlayFab;
using PlayFab.ClientModels;
using TMPro;

public class LeaderBoard : MonoBehaviour
{
    [SerializeField] TMP_InputField currentScore;
    [SerializeField] TextMeshProUGUI Msg;

    [SerializeField]
    public TMP_Text input;
    public void OnButtonGetLeaderboard()
    {
        var lbreq = new GetLeaderboardRequest
        {
            StatisticName = "highscore",
            StartPosition = 0,
            MaxResultsCount = 10
        };

        PlayFabClientAPI.GetLeaderboard(lbreq, OnLeaderboardGet, OnError);
    }
    void OnLeaderboardGet(GetLeaderboardResult r)
    {
        
        string LeaderboardStr = "Leaderboard\n\n" + "";

        foreach (var item in r.Leaderboard)
        {
            string onerow = item.Position + "/" + item.PlayFabId + "/" + item.DisplayName
                + "/" + item.StatValue + "\n";
            LeaderboardStr += onerow; // combine all display into one string 1
        }

        UpdateMsg(LeaderboardStr);
    }

    public void OnButtonSendLeaderboard(int playerScore)
    {
   
        var req = new UpdatePlayerStatisticsRequest
        {
            Statistics = new List<StatisticUpdate>() // playfab leaderboard staticstics name
            {
                new StatisticUpdate
                {
                    StatisticName = "highscore",
                    Value = playerScore
                }
            }
        };

        //UpdateMsg("Submitting score:" + currentScore.text);
        PlayFabClientAPI.UpdatePlayerStatistics(req, OnLeaderboardUpdate, OnError);
    }
    void OnLeaderboardUpdate(UpdatePlayerStatisticsResult r)
    {
        UpdateMsg("Successful leaderboard sent:" + r.ToString());
    }

    public void LoadScene(string scn)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(scn);
    }
    void OnError(PlayFabError e)
    {
        UpdateMsg("Error" + e.GenerateErrorReport());
    }
    void UpdateMsg(string msg)
    {
        Debug.Log(msg);
        Msg.text = msg;
    }
    
}
