using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    [SerializeField]
    private int objectSpawnCount = 30;
    [SerializeField]
    private GameObject[] prefabArray;

    private void Awake()
    {
        for (int i = 0; i < objectSpawnCount; ++ i)
        {
            int index = Random.Range(0, prefabArray.Length);
            float x = Random.Range(-7.5f, 7.5f);    // x 위치
            float y = Random.Range(-4.5f, 4.5f);    // y 위치
            Vector3 position = new Vector3(x, y, 0);

            Instantiate(prefabArray[index], position, Quaternion.identity);
        }
    }
}
