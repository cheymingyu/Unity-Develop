using UnityEngine;

public class DestroySample : MonoBehaviour
{
    [SerializeField]
    private GameObject playerObject;

    private void Awake()
    {
        // playerObject 게임오브젝트의 "PlayerController" 컴포넌트 삭제
        Destroy(playerObject.GetComponent<PlayerController>());
    }
}
