using UnityEngine;

public class DummyNPC : MonoBehaviour
{
    // NPC �̎�ނ��`
    private enum NPCType
    {
        Family,
        Child,
        Elderly,
        Housewife
    }

    // ���݂� NPC �̎�ނ�ێ�
    private NPCType npcType;

    // �e NPC �ɑΉ����� 3D ���f���̃v���n�u
    [SerializeField] private GameObject familyPrefab;
    [SerializeField] private GameObject childPrefab;
    [SerializeField] private GameObject elderlyPrefab;
    [SerializeField] private GameObject housewifePrefab;
    [SerializeField] private GameObject workerPrefab;
    [SerializeField] private GameObject studentPrefab;

    // �C���X�^���X�����ꂽ 3D ���f���̕ێ��p
    private GameObject currentModel;

    // Start is called before the first frame update
    void Start()
    {
      �@// NPC �̎�ނɉ����� 3D ���f���𐶐�
        SpawnModel();
    }

    // NPC �̎�ނɉ����� 3D ���f���𐶐�
    public void  SpawnModel()
    {
        // Enum �̑S�v�f���擾
        NPCType[] npcTypes = (NPCType[])System.Enum.GetValues(typeof(NPCType));
        
        // �����_���� NPC �̎�ނ�����
        npcType = npcTypes[Random.Range(0, npcTypes.Length)];
        
        // ���肵����ނ�\��
        Debug.Log("This NPC is a: " + npcType.ToString());
        
        // �������f��������ꍇ�͍폜
        if (currentModel != null)
        {
            Destroy(currentModel);
        }

        // �K�؂ȃv���n�u��I�����ăC���X�^���X��
        switch (npcType)
        {
            case NPCType.Family:
                currentModel = Instantiate(familyPrefab, transform.position, transform.rotation, transform);
                break;
            case NPCType.Child:
                currentModel = Instantiate(childPrefab, transform.position, transform.rotation, transform);
                break;
            case NPCType.Elderly:
                currentModel = Instantiate(elderlyPrefab, transform.position, transform.rotation, transform);
                break;
            case NPCType.Housewife:
                currentModel = Instantiate(housewifePrefab, transform.position, transform.rotation, transform);
                break;
            default:
                Debug.LogError("Invalid NPC Type");
                break;
        }
    }
}
