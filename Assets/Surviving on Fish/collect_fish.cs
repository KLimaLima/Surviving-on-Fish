using System.Collections.Generic;
using UnityEngine;

public class collect_fish : MonoBehaviour
{
    [SerializeField] private GameObject whereToSpawn;

    private Collider areaToSpawn;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        areaToSpawn = whereToSpawn.GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    // “other” refers to the collider on the GameObject inside this trigger
    void OnTriggerEnter(Collider other)
    {
        //Debug.Log("A collider has entered the DoorObject trigger");

        // If not fish tag then finish
        if (other.tag != "Fish") { return; }

        Vector3 randomPosition = new Vector3(Random.Range(areaToSpawn.bounds.min.x, areaToSpawn.bounds.max.x), (areaToSpawn.bounds.max.y + 0.1f), Random.Range(areaToSpawn.bounds.min.z, areaToSpawn.bounds.max.z));

        // gets the rigidbody of other aka gameobject and teleports it to randomPostion
        other.GetComponent<Rigidbody>().position = randomPosition;

        //GameData.Instance.amountGive += 1;
        //GameData.Instance.fishObjects.Add(other.gameObject);
    }
}
