using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class levelloader : MonoBehaviour
{
    public Animator transition;

    public float transitionTime = 1f;
    public int indexTo;

    public void LoadNextLevel()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + indexTo));
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