using TMPro;
using UnityEngine;

public class display_score : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreUI;
    string scoreText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        CheckData();
    }

    // Update is called once per frame
    void Update()
    {
        CheckData();
    }

    void CheckData()
    {
        string scoreText = GameData.Instance.score.ToString();
        string fishNeedText = GameData.Instance.amountFishNeed.ToString();
        string textUI = $"How much this person needs: {fishNeedText}\nScore: {scoreText}";
        scoreUI.text = textUI;
    }
}
