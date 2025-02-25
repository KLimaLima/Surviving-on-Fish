using TMPro;
using Unity.XR.CoreUtils;
using UnityEngine;

public class ScoringUI : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreUIText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Scoring();
    }

    // Update is called once per frame
    void Update()
    {
        Scoring();
    }

    void Scoring()
    {
        string scoreText = GameData.Instance.last_score.ToString();
        string textUI = $"Total Score:\n{scoreText}";
        scoreUIText.text = textUI;
    }
}
