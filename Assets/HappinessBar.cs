using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode()]
public class HappinessBar : MonoBehaviour
{
    public int minimum;
    public int maximum;
    public int current;
    public Image mask;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        GetCurrentFill();
    }
    void GetCurrentFill()
    {
        float currentOffset = current - minimum;
        float maximumOffset = maximum - minimum;
        float fillAmount = currentOffset / maximumOffset;
        mask.fillAmount = fillAmount;   

    }
}
