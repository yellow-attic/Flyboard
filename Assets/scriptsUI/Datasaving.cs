using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Datasaving : MonoBehaviour
{
    #region Singleton
    public static Datasaving Instance;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        // 检查是否已存在此对象，如果有则销毁新对象，确保只有一个对象存在
        GameObject[] objs = GameObject.FindGameObjectsWithTag("Data");
        if (objs.Length > 1)
        {
            Destroy(gameObject);
            return;
        }

        // 将此对象标记为永久对象
        DontDestroyOnLoad(gameObject);
    }

    #endregion


    private List<string> leaderboardNames = new List<string>(); // 存储玩家名字的列表
    private List<int> leaderboardScores = new List<int>(); // 存储玩家分数的列表

    private const string PlayerPrefsKey = "HighScoreLeaderboard";

    private void Start()
    {
        LoadLeaderboard();
    }

    //private void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.Tab))
    //    {
    //        PlayerPrefs.DeleteAll();
    //        Debug.Log("PlayerPrefs data has been cleaned.");
    //    }
    //}

    private void LoadLeaderboard()
    {
        // 从PlayerPrefs中加载排行榜数据
        string leaderboardData = PlayerPrefs.GetString(PlayerPrefsKey);

        if (!string.IsNullOrEmpty(leaderboardData))
        {
            // 解析存储的排行榜数据
            string[] entries = leaderboardData.Split(';');

            for (int i = 0; i < entries.Length - 1; i++)
            {
                string[] parts = entries[i].Split(',');
                string playerName = parts[0];
                int playerScore = int.Parse(parts[1]);

                leaderboardNames.Add(playerName);
                leaderboardScores.Add(playerScore);

                Debug.Log(parts[0] + "playerScore =" + int.Parse(parts[1]));
            }

            // 根据分数对排行榜进行排序（从高到低）
            SortLeaderboard();
        }
    }

    private void SaveLeaderboard()
    {
        // 将排行榜数据保存到PlayerPrefs中
        string leaderboardData = "";

        for (int i = 0; i < leaderboardNames.Count; i++)
        {
            string entry = leaderboardNames[i] + "," + leaderboardScores[i];
            leaderboardData += entry + ";";
        }

        PlayerPrefs.SetString(PlayerPrefsKey, leaderboardData);
    }

    public void AddScoreToLeaderboard(string playerName, int score)
    {
        // 将玩家的名字和分数添加到排行榜
        leaderboardNames.Add(playerName);
        leaderboardScores.Add(score);

        // 根据分数对排行榜进行排序（从高到低）
        SortLeaderboard();

        // 限制排行榜数据只保留前7名
        //if (leaderboardNames.Count > 7)
        //{
        //    leaderboardNames.RemoveAt(7);
        //    leaderboardScores.RemoveAt(7);
        //}

        // 更新排行榜UI显示


        // 保存排行榜数据到PlayerPrefs
        SaveLeaderboard();
    }

    private void SortLeaderboard()
    {
        for (int i = 0; i < leaderboardScores.Count - 1; i++)
        {
            for (int j = i + 1; j < leaderboardScores.Count; j++)
            {
                if (leaderboardScores[j] > leaderboardScores[i])
                {
                    // 交换分数和名字的位置
                    int tempScore = leaderboardScores[i];
                    leaderboardScores[i] = leaderboardScores[j];
                    leaderboardScores[j] = tempScore;

                    string tempName = leaderboardNames[i];
                    leaderboardNames[i] = leaderboardNames[j];
                    leaderboardNames[j] = tempName;
                }
            }
        }
    }

    public List<string> HighscoreName()
    {
        return leaderboardNames;
    }

    public List<int> HighscoreScore()
    {
        return leaderboardScores;
    }


    private int currentscore;



    public void GetScore(int newscore)
    {
        currentscore = newscore;
    }

    public int updateScore()
    {
        return currentscore;
    }


    public int calculateDeliverySum()
    {
        int deliverysum = currentscore / 10;

        return deliverysum;
    }
}
