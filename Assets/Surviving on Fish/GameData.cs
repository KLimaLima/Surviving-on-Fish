using System.Collections.Generic;
using UnityEngine;

public class GameData : MonoBehaviour
{
    public static GameData Instance;

    //Add public variable here
    public int amountFish = 0;
    public int amountGive = 0;
    public List<GameObject> fishCaughtObjects = new List<GameObject>();
    public List<GameObject> fishToGiveObjects = new List<GameObject>();

    public int score = 0;
    public int amountFishNeed = 0;
    public int last_score = 0;
    public int new_happiness = 50;

    void Update()
    {
        Debug.Log(last_score);
    }

    //Add public variable above this comment

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(Instance);
            return;
        }

        Instance = this;

        DontDestroyOnLoad(gameObject);
    }
}