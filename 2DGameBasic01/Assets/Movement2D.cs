
using UnityEngine;

public class Movement2D : MonoBehaviour
{
    private void Update()
    {
        // ���ο� ��ġ = ���� ��ġ + (���� * �ӵ�)
        //transform.position = transform.position + new Vector3(1, 0, 0) * 1;

        transform.position += Vector3.right * 1 * Time.deltaTime;
    }

}
