using UnityEngine;

public class Movement2D : MonoBehaviour
{
    [SerializeField]
    private float   speed = 5.0f;               // 이동 속도
    [SerializeField]
    private float jumpForce = 8.0f;             // 점프 힘 (클수록 높게 점프)
    private Rigidbody2D rigid2D;
    [HideInInspector]
    public bool isLongJump = false;             // 낮은 점프, 높은 점프 체크

    private void Awake()
    {
        rigid2D = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        // 낮은 점프, 높은 점프 구현을 위한 중력 계수(gravityScale) 조절 (Jump Up일 때만 적용)
        // 중력 계수가 낮은 if 문은 높은 점프가 되고, 중력 계수가 높은 else 문은 낮은 점프가 된다.
        if (isLongJump && rigid2D.velocity.y > 0)
        {
            rigid2D.gravityScale = 1.0f;
        }
        else
        {
            rigid2D.gravityScale = 2.5f;
        }
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
