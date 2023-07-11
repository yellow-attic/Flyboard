using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Ranking : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI[] playerNames; // 用于显示玩家名字的文本组件数组
    TextMeshProUGUI[] playerScores; // 用于显示玩家分数的文本组件数组
    TextMeshProUGUI[] playerNr; // 用于显示玩家分数的文本组件数组



    private void Start()
    {
        playerScores = new TextMeshProUGUI[playerNames.Length];
        playerNr = new TextMeshProUGUI[playerNames.Length];

        for (int i = 0; i < playerNames.Length; i++)
        {
            playerScores[i] = playerNames[i].transform.Find("score").GetComponent<TextMeshProUGUI>();
            playerNr[i] = playerNames[i].transform.Find("nr").GetComponent<TextMeshProUGUI>();
        }

        UpdateLeaderboardUI();
    }



    private void UpdateLeaderboardUI()
    {
        List<string> leaderboardNames;
        List<int> leaderboardScores;

        leaderboardNames = Datasaving.Instance.HighscoreName();
        leaderboardScores = Datasaving.Instance.HighscoreScore();

        for (int i = 0; i < playerNames.Length; i++)
        {
            if (i < leaderboardNames.Count && i < leaderboardScores.Count)
            {
                playerNames[i].text = leaderboardNames[i];
                playerScores[i].text = leaderboardScores[i].ToString();
                playerNr[i].text = (i + 1).ToString() + ".";
            }
            else
            {
                // 如果排行榜数据不足，则将剩余的文本组件内容清空
                playerNames[i].text = "";
                playerScores[i].text = "";
                playerNr[i].text = "";
            }
        }
    }
}