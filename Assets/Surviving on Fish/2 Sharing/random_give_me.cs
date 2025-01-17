using UnityEngine;

public class random_give_me : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        NewCustomer();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private int penaltyFactor = 2;
    private int baseReward = 11;
    public void Count_Score()
    {
        int givenDiff = Mathf.Abs(GameData.Instance.amountGive - GameData.Instance.amountFishNeed);

        float penaltyScore = Mathf.Pow(penaltyFactor, givenDiff);

        float calcScore = baseReward - penaltyScore;

        GameData.Instance.score = (int)calcScore;

        GameData.Instance.amountGive = 0;

        foreach (var destroyMe in GameData.Instance.fishToGiveObjects)
        {
            Destroy(destroyMe);
        }

        NewCustomer();
    }

    private void NewCustomer()
    {
        GameData.Instance.amountFishNeed = Random.Range(1, 8);
    }
}
