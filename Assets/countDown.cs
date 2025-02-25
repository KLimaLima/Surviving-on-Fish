using UnityEngine;
using UnityEngine.SceneManagement;

public class countDown : MonoBehaviour
{
    private float timePassed = 0;
    [SerializeField] private levelloader nextLevelLoader;
    [SerializeField] private int indexTo;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timePassed += Time.deltaTime;
        if (timePassed > 300) //5mins
        {
            StartCoroutine(nextLevelLoader.LoadLevel(SceneManager.GetActiveScene().buildIndex + indexTo));
        }
    }
}
