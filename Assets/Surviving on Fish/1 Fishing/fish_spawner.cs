using UnityEngine;

public class fish_spawner : MonoBehaviour
{

    [SerializeField] public GameObject fishPrefab;
    private bool canSpawn;
    private Collider areaToSpawn;

    [SerializeField] public Vector3 objectPosition;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        canSpawn = false;
        areaToSpawn = GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!canSpawn) { return; }

        if (Random.Range(0, 100) < 90) { return; }

        Vector3 randomPosition = new Vector3(Random.Range(areaToSpawn.bounds.min.x, areaToSpawn.bounds.max.x), (areaToSpawn.bounds.max.y + 0.1f), Random.Range(areaToSpawn.bounds.min.z, areaToSpawn.bounds.max.z));
        Instantiate(fishPrefab, randomPosition, Quaternion.identity);
    }

    // “other” refers to the collider on the GameObject inside this trigger
    void OnTriggerEnter(Collider other)
    {
        canSpawn = true;
    }

    void OnTriggerStay(Collider other)
    {

    }

    void OnTriggerExit(Collider other)
    {
        canSpawn = false;
    }
}
