using UnityEngine;
using System.Collections;

public class trigger_test : MonoBehaviour
{
    private GameData data;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //data = GameData.Instance;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(data.amountGive.ToString());
    }
    // “other” refers to the collider on the GameObject inside this trigger
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("A collider has entered the DoorObject trigger");
        GameData.Instance.amountGive += 1;
    }

    void OnTriggerStay(Collider other)
    {
        Debug.Log("A collider is inside the DoorObject trigger");
    }

    void OnTriggerExit(Collider other)
    {
        GameData.Instance.amountGive -= 1;
        // Debug.Log(GameData.Instance.amountGive);
    }
}
