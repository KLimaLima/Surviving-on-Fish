using UnityEngine;

public class ScoreBasedExpression : MonoBehaviour
{
    public AnimationController animationController;

    private int previousScore = 0;

    void Start()
    {
        if (animationController == null)
        {
            animationController = GetComponent<AnimationController>();
        }

        UpdateExpression(GameData.Instance.score);
    }

    void Update()
    {
        if (GameData.Instance.score != previousScore)
        {
            UpdateExpression(GameData.Instance.score);
            previousScore = GameData.Instance.score;
        }
    }

    private void UpdateExpression(int score)
    {
        if (animationController == null) return;

        if (score >= 8)  // スコアが高いとHappy
        {
            animationController.ChangeExpression(AnimationController.ExpressionType.Happy);
        }
        else if (score <= 3)  // スコアが低いとSad
        {
            animationController.ChangeExpression(AnimationController.ExpressionType.Sad);
        }
        else  // 中間ならNeutral（なし）
        {
            animationController.ChangeExpression(AnimationController.ExpressionType.None);
        }
    }
}
