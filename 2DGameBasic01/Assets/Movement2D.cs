using UnityEngine;

public class Movement2D : MonoBehaviour
{
    [SerializeField]
    private float   speed = 5.0f;               // 이동 속도
    [SerializeField]
    private float jumpForce = 8.0f;             // 점프 힘 (클수록 높게 점프)
    private Rigidbody2D rigid2D;

    private void Awake()
    {
        rigid2D = GetComponent<Rigidbody2D>();
    }

    public void Move(float x)
    {
        // x축 이동은 x * speed로, y축 이동은 기존의 속력 값(현재는 중력)
        rigid2D.velocity = new Vector2(x * speed, rigid2D.velocity.y);
    }

    public void Jump()
    {
        rigid2D.velocity = Vector2.up * jumpForce;
    }

}
