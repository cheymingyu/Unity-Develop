using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private KeyCode keyCodeFire = KeyCode.Space;
    [SerializeField]
    private GameObject bulletPrefab;
    private float moveSpeed = 3.0f;

    private void Update()
    {
        // �÷��̾� ������Ʈ �̵�
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        transform.position += new Vector3(x, y, 0) * moveSpeed * Time.deltaTime;

        // �÷��̾� ������Ʈ �Ѿ� �߻�
        if (Input.GetKeyDown(keyCodeFire))
        {
            GameObject clone = Instantiate(bulletPrefab, transform.position, Quaternion.identity);

            clone.name = "Bullet";
            clone.transform.localScale = Vector3.one * 0.5f;
            clone.GetComponent<SpriteRenderer>().color = Color.red;
        }
    }
}
