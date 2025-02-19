using System.Collections.Generic;
using UnityEngine;

public class CaughtFishSpawner : MonoBehaviour
{
    [SerializeField] private GameObject DummyFishPrefab;
    [SerializeField] private GameObject FishSpawnArea;
    private Collider areaToSpawn;
    private List<GameObject> spawnedFishList = new List<GameObject>();
    private int previousAmountFish;

    void Start()
    {
        areaToSpawn = FishSpawnArea.GetComponent<Collider>();
        previousAmountFish = GameData.Instance.amountFish;
        UpdateDummyFish();
    }

    void Update()
    {
        if (GameData.Instance.amountFish != previousAmountFish)
        {
            UpdateDummyFish();
            previousAmountFish = GameData.Instance.amountFish;
        }
    }

    private void UpdateDummyFish()
    {
        // 既存のDummyFishを削除
        foreach (var fish in spawnedFishList)
        {
            Destroy(fish);
        }
        spawnedFishList.Clear();

        // 新しいDummyFishを生成
        for (int i = 0; i < GameData.Instance.amountFish; i++)
        {
            Vector3 randomPosition = GetRandomPositionInCapsule();
            GameObject newFish = Instantiate(DummyFishPrefab, randomPosition, Quaternion.identity);
            spawnedFishList.Add(newFish);
        }
    }

    private Vector3 GetRandomPositionInCapsule()
    {
        CapsuleCollider capsule = areaToSpawn as CapsuleCollider;
        if (capsule == null)
        {
            Debug.LogError("FishSpawnArea に Capsule Collider がアタッチされていません。");
            return Vector3.zero;
        }

        Vector3 center = capsule.bounds.center;
        float radius = capsule.radius;
        float height = capsule.height / 2 - radius;

        // 円の中にランダムな位置を取得
        Vector2 randomCircle = Random.insideUnitCircle * radius;
        float randomHeight = Random.Range(-height, height);

        Vector3 randomPosition = center + new Vector3(randomCircle.x, randomHeight, randomCircle.y);

        return randomPosition;
    }
}
