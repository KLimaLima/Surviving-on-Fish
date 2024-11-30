using UnityEngine;

public class GameData : MonoBehaviour
{
    public static GameData Instance;

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
