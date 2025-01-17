using UnityEngine;

public class random_give_me : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Count_Score()
    {
        GameData.Instance.amountGive = 0;

        foreach (var destroyMe in GameData.Instance.fishToGiveObjects)
        {
            Destroy(destroyMe);
        }
    }
}
