using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject[] prefabArray;

    private void Awake()
    {
        for (int i = 0; i < 10; i ++)
        {
            int index = Random.Range(0, prefabArray.Length);
            Vector3 position = new Vector3(-4.5f + i, 0, 0);

            Instantiate(prefabArray[index], position, Quaternion.identity);
        }
    }
}
