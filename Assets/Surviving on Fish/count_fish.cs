using UnityEngine;

public class count_fish : MonoBehaviour
{

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(GameData.Instance.amountGive);
    }

    // “other” refers to the collider on the GameObject inside this trigger
    void OnTriggerEnter(Collider other)
    {
        //Debug.Log("A collider has entered the DoorObject trigger");

        // If not fish tag then finish
        if (other.tag != "Fish") { return; }

        GameData.Instance.amountGive += 1;
        GameData.Instance.fishObjects.Add(other.gameObject);
    }

    void OnTriggerStay(Collider other)
    {
        //Debug.Log("A collider is inside the DoorObject trigger");
    }

    void OnTriggerExit(Collider other)
    {
        // If not fish tag then finish
        if (other.tag != "Fish") { return; }

        GameData.Instance.amountGive -= 1;
        GameData.Instance.fishObjects.Remove(other.gameObject);
        // Debug.Log(GameData.Instance.amountGive);
    }
}
