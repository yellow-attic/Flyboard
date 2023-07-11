using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class Scorerecord : MonoBehaviour
{
    [SerializeField] private TMP_InputField inputField;
    [SerializeField] private TextMeshProUGUI scoretext;

    int _score;

    void Start()
    {
        _score = Datasaving.Instance.updateScore();
        scoretext.text = _score.ToString();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            GetTextFromInputField();
        }
    }

    public void GetTextFromInputField()
    {
        if (inputField.text != null)
        {
            string inputText = inputField.text;
            Debug.Log("Input Text: " + inputText);

            Datasaving.Instance.AddScoreToLeaderboard(inputText, _score);
        }
    }

}