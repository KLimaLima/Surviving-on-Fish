using System.Collections.Generic;
using UnityEngine;

public class CaughtFishSpawner : MonoBehaviour
{
    [SerializeField] private GameObject dummyFishPrefab;
    [SerializeField] private Transform fishSpawnArea;

    private List<GameObject> spawnedDummyFish = new List<GameObject>();
    private int previousAmountFish;

    void Start()
    {
        previousAmountFish = GameData.Instance.amountFish;
        UpdateDummyFish();
    }

    void Update()
    {
        // amountFish の値が変わった場合にのみ更新
        if (GameData.Instance.amountFish != previousAmountFish)
        {
            UpdateDummyFish();
            previousAmountFish = GameData.Instance.amountFish;
        }
    }

    // DummyFish の生成または削除を行う
    private void UpdateDummyFish()
    {
        int currentAmountFish = GameData.Instance.amountFish;

        // 生成
        if (currentAmountFish > spawnedDummyFish.Count)
        {
            int fishToSpawn = currentAmountFish - spawnedDummyFish.Count;
            for (int i = 0; i < fishToSpawn; i++)
            {
                GameObject newFish = Instantiate(dummyFishPrefab, GetRandomPosition(), Quaternion.identity, fishSpawnArea);
                spawnedDummyFish.Add(newFish);
            }
        }
        // 削除
        else if (currentAmountFish < spawnedDummyFish.Count)
        {
            int fishToRemove = spawnedDummyFish.Count - currentAmountFish;
            for (int i = 0; i < fishToRemove; i++)
            {
                GameObject fishToDelete = spawnedDummyFish[spawnedDummyFish.Count - 1];
                spawnedDummyFish.RemoveAt(spawnedDummyFish.Count - 1);
                Destroy(fishToDelete);
            }
        }
    }

    // スポーンエリア内のランダムな位置を取得
    private Vector3 GetRandomPosition()
    {
        Vector3 areaSize = fishSpawnArea.localScale;
        Vector3 areaPosition = fishSpawnArea.position;

        float randomX = Random.Range(areaPosition.x - areaSize.x / 2, areaPosition.x + areaSize.x / 2);
        float randomY = areaPosition.y;
        float randomZ = Random.Range(areaPosition.z - areaSize.z / 2, areaPosition.z + areaSize.z / 2);

        return new Vector3(randomX, randomY, randomZ);
    }
}
