using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class levelloader : MonoBehaviour
{
    public Animator transition;

    public float transitionTime = 1f; 

    // Update is called once per frame
    void Update()
    {
 /*       if (Input.GetMouseButtonDown(0))
        {
            LoadNextLevel();
        }*/
    }

    public void LoadNextLevel()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex - 1));
    }

    IEnumerator LoadLevel(int levelIndex)
    {
        //Play animation
        transition.SetTrigger("start"); 

        //The interval between tranition
        yield return new WaitForSeconds(2);

        //Load scene
        SceneManager.LoadScene(levelIndex);
    }
}