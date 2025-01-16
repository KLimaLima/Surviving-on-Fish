using System.Collections.Generic;
using UnityEngine;

public class GameData : MonoBehaviour
{
    public static GameData Instance;

    //Add public variable here
    public int amountFish;
    public int amountGive = 0;
    public List<GameObject> fishObjects = new List<GameObject>();

    void Update()
    {
        Debug.Log(amountGive);
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