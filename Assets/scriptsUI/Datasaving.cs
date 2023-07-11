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


    private int score;
    private int highscore;
    //private string scoreKey = "PlayerScore";

    private void Start()
    {
        // Check if the score is stored in PlayerPrefs
        //if (PlayerPrefs.HasKey(scoreKey))
        //{
        //    // Get the score from PlayerPrefs
        //    score = PlayerPrefs.GetInt(scoreKey);
        //}
        //else
        //{
        //    // Initialize the score
        //    score = 0;
        //}

        score = 0;

        Debug.Log(score);
    }


    public void GetScore(int newscore)
    {
        score = newscore;

        // Store the score in PlayerPrefs
       // PlayerPrefs.SetInt(scoreKey, score);
        //_eggkidcounter.text = score.ToString();
    }

    public int updateScore()
    {
        return score;
    }

    //public void ResetScore(string code)
    //{
    //    if (code == "reset")
    //        score = 0;

    //   // PlayerPrefs.SetInt(scoreKey, score);
    //    //_eggkidcounter.text = score.ToString();
    //}

    public int calculateDeliverySum()
    {
        int deliverysum = score / 10;

        return deliverysum;
    }

    void Update()
    {
        
    }
}
