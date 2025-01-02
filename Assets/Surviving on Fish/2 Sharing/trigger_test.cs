using UnityEngine;
using System.Collections;

public class trigger_test : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    // “other” refers to the collider on the GameObject inside this trigger
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("A collider has entered the DoorObject trigger");
    }

    void OnTriggerStay(Collider other)
    {
        Debug.Log("A collider is inside the DoorObject trigger");
    }

    void OnTriggerExit(Collider other)
    {
        Debug.Log("A collider has exited the DoorObject trigger");
    }
}
