using UnityEngine;

public class FishSpawner : MonoBehaviour
{
    [SerializeField] private GameObject fishPrefab;  // 魚のPrefab
    [SerializeField] private Transform bucketTransform; // 桶のTransform
    [SerializeField] private float spawnHeightOffset = 1.0f; // 桶の上部よりどれくらい高い位置にスポーンするか

    public void SpawnFish()
    {
        if (fishPrefab == null || bucketTransform == null)
        {
            Debug.LogError("FishPrefab または BucketTransform が設定されていません！");
            return;
        }

        // 桶の上部の位置を計算
        Vector3 spawnPosition = bucketTransform.position + new Vector3(0, spawnHeightOffset, 0);

        // 魚を生成
        GameObject fish = Instantiate(fishPrefab, spawnPosition, Quaternion.identity);

        // 魚にRigidbodyがない場合は追加
        Rigidbody fishRb = fish.GetComponent<Rigidbody>();
        if (fishRb == null)
        {
            fishRb = fish.AddComponent<Rigidbody>();
        }

        fishRb.useGravity = true;  // 重力を有効にする
        fishRb.mass = 0.5f;  // 落下の挙動を調整
    }
}
