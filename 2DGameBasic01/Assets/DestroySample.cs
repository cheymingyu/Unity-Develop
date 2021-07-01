using UnityEngine;

public class DestroySample : MonoBehaviour
{
    [SerializeField]
    private GameObject playerObject;

    private void Awake()
    {
        // playerObject ���ӿ�����Ʈ�� "PlayerController" ������Ʈ ����
        Destroy(playerObject.GetComponent<PlayerController>());
    }
}
