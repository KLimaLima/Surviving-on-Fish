using UnityEngine;
using System.Collections;

public class NPCManager : MonoBehaviour
{
    public GameObject[] npcPrefabs; // 4種類のNPCのPrefab
    public Transform spawnPoint; // NPCを生成する位置
    private GameObject currentNPC; // 現在のNPC
    private AnimationController npcAnimationController; // NPCのAnimationController

    // NPC の種類を定義
    private enum NPCType
    {
        Male,
        Female,
        ChildMale,
        ChildFemale
    }

    private NPCType npcType;

    private int penaltyFactor = 2;
    private int baseReward = 11;

    void Start()
    {
        // 初期化時にNPC生成を行わず、必要な時に生成する
    }

    public void OnScoreCalculated()
    {
        // スコア計算後、NPCを歩かせて後方に移動させ、その後削除
        StartCoroutine(MoveAndDestroyNPC(Vector3.back * 2.0f, 2.0f));
    }

    private IEnumerator MoveAndDestroyNPC(Vector3 moveDistance, float duration)
    {
        if (currentNPC == null) yield break;

        // NPCの初期位置
        Vector3 startPosition = currentNPC.transform.position;
        Vector3 endPosition = startPosition + moveDistance;
        float elapsed = 0f;

        // NPCを後方に移動させる
        while (elapsed < duration)
        {
            currentNPC.transform.position = Vector3.Lerp(startPosition, endPosition, elapsed / duration);
            elapsed += Time.deltaTime;
            yield return null;
        }

        // 移動完了後の最終位置
        currentNPC.transform.position = endPosition;

        // NPCを削除
        Destroy(currentNPC);
        currentNPC = null;

        // 新しいNPCを生成して登場
        SpawnNewNPC();
    }

    private void SpawnNewNPC()
    {
        // NPCの種類をランダムに選択
        npcType = (NPCType)Random.Range(0, System.Enum.GetValues(typeof(NPCType)).Length);

        // NPCの種類に基づいてPrefabを選択
        GameObject selectedPrefab = GetNPCPrefabByType(npcType);

        if (selectedPrefab != null)
        {
            // 新しいNPCを生成
            currentNPC = Instantiate(selectedPrefab, spawnPoint.position + Vector3.back * 2.0f, Quaternion.identity);

            // NPCのAnimationControllerを取得して、歩きながら前に移動させる
            npcAnimationController = currentNPC.GetComponent<AnimationController>();
            StartCoroutine(MoveNPC(Vector3.forward * 2.0f, 2.0f));
        }
    }

    private GameObject GetNPCPrefabByType(NPCType type)
    {
        // NPCの種類に対応したPrefabを返す
        switch (type)
        {
            case NPCType.Male:
                return npcPrefabs[0]; // Male
            case NPCType.Female:
                return npcPrefabs[1]; // Female
            case NPCType.ChildMale:
                return npcPrefabs[2]; // ChildMale
            case NPCType.ChildFemale:
                return npcPrefabs[3]; // ChildFemale
            default:
                return null;
        }
    }

    private IEnumerator MoveNPC(Vector3 moveDistance, float duration)
    {
        if (currentNPC == null) yield break;

        // NPCの初期位置
        Vector3 startPosition = currentNPC.transform.position;
        Vector3 endPosition = startPosition + moveDistance;
        float elapsed = 0f;

        // NPCを前方に移動させる
        while (elapsed < duration)
        {
            currentNPC.transform.position = Vector3.Lerp(startPosition, endPosition, elapsed / duration);
            elapsed += Time.deltaTime;
            yield return null;
        }

        // 移動完了後の最終位置
        currentNPC.transform.position = endPosition;
    }
}
