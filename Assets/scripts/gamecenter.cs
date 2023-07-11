using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class gamecenter : MonoBehaviour
{
    [Header("Score")]
    [SerializeField] TextMeshProUGUI scoretext;
    [SerializeField] float addspeed = 0.1f;
    int scoresum = 0;
    int currentscore = 0;

    [Header("Lanch Deliveryman")]
    public bool readytolaunch = false;
    [SerializeField] GameObject readyman;
    [SerializeField] GameObject rolinman;

    [Header("Game Setting")]
    [SerializeField] LevelDifficult level;
    [SerializeField] GameObject gameover;

    bool isstart = false;


    // Start is called before the first frame update
    void Start()
    {
        scoretext.text = "0";
    }

     void Update()
    {
        //Test();
        LaunchMan();
    }

    public void CountOrders()
    {
        scoresum += 10;

        Datasaving.Instance.GetScore(scoresum);
        StartCoroutine(ShowScore());
    }

    IEnumerator ShowScore()
    {
        for (int i = 0; i < 10; i++)
        {
            currentscore += 1;
            scoretext.text = (currentscore).ToString();
            yield return new WaitForSeconds(addspeed);   // 等待
        }
    }

    void LaunchMan()
    {
        if (readytolaunch)
        {
            if (Input.GetMouseButtonDown(0) && !isstart)
            {
                rolinman.transform.position = readyman.transform.position;

                readyman.SetActive(false);
                rolinman.SetActive(true);
                level.enabled = true;

                isstart = true;
            }
        }

    }

    public void endGame()
    {
        gameover.SetActive(true);
    }

    //void Test()
    //{
    //    if (Input.GetKeyDown(KeyCode.R))
    //    {
    //        SceneManager.LoadScene(0);
    //    }
    //}
}
