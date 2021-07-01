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

    [SerializeField]
    private LayerMask           groundLayer;        // 바닥 체크를 위한 충돌 레이어
    private CapsuleCollider2D   capsuleCollider2D;  // 오브젝트의 충돌 범위 컴포넌트
    private bool                isGrounded;         // 바닥 체크 (바닥에 닿아있을 때 true)
    private Vector3             footPosition;       // 발의 위치

    private void Awake()
    {
        rigid2D = GetComponent<Rigidbody2D>();
        capsuleCollider2D = GetComponent<CapsuleCollider2D>();
    }

    private void FixedUpdate()
    {
        // 플레이어 오브젝트의 Collider2D min, center, max 위치 정보
        Bounds bounds = capsuleCollider2D.bounds;
        // 플레이어의 발 위치 설정
        footPosition = new Vector2(bounds.center.x, bounds.min.y);
        // 플레이어의 발 위치에 원을 생성하고, 원이 바닥과 닿아있으면 isGrounded = true
        isGrounded = Physics2D.OverlapCircle(footPosition, 0.1f, groundLayer);

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

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawSphere(footPosition, 0.1f);
    }

    public void Move(float x)
    {
        // x축 이동은 x * speed로, y축 이동은 기존의 속력 값(현재는 중력)
        rigid2D.velocity = new Vector2(x * speed, rigid2D.velocity.y);
    }

    public void Jump()
    {
        if (isGrounded == true)
        {
            rigid2D.velocity = Vector2.up * jumpForce;
        }
    }

}
