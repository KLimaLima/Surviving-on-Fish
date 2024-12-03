using UnityEngine;

public class GameData : MonoBehaviour
{
    public static GameData Instance;

    //Add public variable here

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