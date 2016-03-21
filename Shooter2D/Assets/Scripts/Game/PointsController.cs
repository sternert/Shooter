using UnityEngine;
using UnityEngine.UI;

public class PointsController : MonoBehaviour 
{
    public Text uiText;
    public string pre;
    public string post;

    private int totalScore;

    void Start()
    {
        totalScore = 0;
        UpdateScore();
    }

    public void AddScore(int addScore)
    {
        totalScore += addScore;
        UpdateScore();
    }

    void UpdateScore()
    {
        uiText.text = pre + totalScore + post;
    }
}