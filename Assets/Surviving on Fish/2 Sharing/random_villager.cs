using UnityEngine;

public class DummyNPC : MonoBehaviour
{
    // NPC の種類を定義
    private enum NPCType
    {
        Male,
        Female,
        ChildMale,
        ChildFemale
    }

    // 現在の NPC の種類を保持
    private NPCType npcType;

    // 各 NPC に対応する 3D モデルのプレハブ
    [SerializeField] private GameObject malePrefab;
    [SerializeField] private GameObject femalePrefab;
    [SerializeField] private GameObject childmalePrefab;
    [SerializeField] private GameObject childfemalePrefab;
    //[SerializeField] private GameObject workerPrefab;
    //[SerializeField] private GameObject studentPrefab;

    // インスタンス化された 3D モデルの保持用
    private GameObject currentModel;

    // Start is called before the first frame update
    void Start()
    {
        // NPC の種類に応じて 3D モデルを生成
        SpawnModel();
    }

    // NPC の種類に応じて 3D モデルを生成
    public void  SpawnModel()
    {
        // Enum の全要素を取得
        NPCType[] npcTypes = (NPCType[])System.Enum.GetValues(typeof(NPCType));
        
        // ランダムに NPC の種類を決定
        npcType = npcTypes[Random.Range(0, npcTypes.Length)];
        
        // 決定した種類を表示
        Debug.Log("This NPC is a: " + npcType.ToString());
        
        // 既存モデルがある場合は削除
        if (currentModel != null)
        {
            Destroy(currentModel);
        }

        // 適切なプレハブを選択してインスタンス化
        switch (npcType)
        {
            case NPCType.Male:
                currentModel = Instantiate(malePrefab, transform.position, transform.rotation, transform);
                break;
            case NPCType.Female:
                currentModel = Instantiate(femalePrefab, transform.position, transform.rotation, transform);
                break;
            case NPCType.ChildMale:
                currentModel = Instantiate(childmalePrefab, transform.position, transform.rotation, transform);
                break;
            case NPCType.ChildFemale:
                currentModel = Instantiate(childfemalePrefab, transform.position, transform.rotation, transform);
                break;
            default:
                Debug.LogError("Invalid NPC Type");
                break;
        }
    }
}
