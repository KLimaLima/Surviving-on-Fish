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

    public void Count_Score()//since this function is small, no seperation to other file is needed
    {
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