using System;
using UnityEngine;

public class count_fish : MonoBehaviour
{
    private enum WhatVar
    {
        amountFish,
        amountGive
    }

    [SerializeField] private WhatVar whatVar;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("amountFish");
        Debug.Log(GameData.Instance.amountFish);
        Debug.Log("amountGive");
        Debug.Log(GameData.Instance.amountGive);
    }

    // “other” refers to the collider on the GameObject inside this trigger
    void OnTriggerEnter(Collider other)
    {
        //Debug.Log("A collider has entered the DoorObject trigger");

        // If not fish tag then finish
        if (other.tag != "Fish") { return; }

        switch (whatVar)
        {
            case WhatVar.amountFish:
                GameData.Instance.amountFish += 1;
                GameData.Instance.fishCaughtObjects.Add(other.gameObject);
                break;

            case WhatVar.amountGive:
                GameData.Instance.amountGive += 1;
                GameData.Instance.fishToGiveObjects.Add(other.gameObject);
                break;

            default:
                Debug.Log("Error: No variable in GameData chosen");
                break;
        }
        //GameData.Instance.amountGive += 1;
    }

    void OnTriggerStay(Collider other)
    {
        //Debug.Log("A collider is inside the DoorObject trigger");
    }

    void OnTriggerExit(Collider other)
    {
        // If not fish tag then finish
        if (other.tag != "Fish") { return; }

        switch (whatVar)
        {
            case WhatVar.amountFish:
                GameData.Instance.amountFish -= 1;
                GameData.Instance.fishCaughtObjects.Remove(other.gameObject);
                break;

            case WhatVar.amountGive:
                GameData.Instance.amountGive -= 1;
                GameData.Instance.fishToGiveObjects.Remove(other.gameObject);
                break;

            default:
                Debug.Log("Error: No variable in GameData chosen");
                break;
        }
        //GameData.Instance.amountGive -= 1;
        // Debug.Log(GameData.Instance.amountGive);
    }
}
