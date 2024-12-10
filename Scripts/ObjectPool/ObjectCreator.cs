using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectCreator : MonoBehaviour
{
    public GameObject prefab;
    public int CreateCount;
    private List<GameObject> objects = new List<GameObject>();

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            for (int i = 0; i < CreateCount; i++)
            {
                float x = Random.Range(-100f, 100f);
                float z = Random.Range(-100f, 100f);
                float y = Random.Range(-100f, 100f);
                var go =Instantiate(prefab, new Vector3(x, y, z), Quaternion.identity);
                objects.Add(go);
            }
        }
        else if (Input.GetKeyDown(KeyCode.Delete))
        {
            for (int i = 0; i < CreateCount; i++)
            {
                Destroy(objects[i]);
            }
            objects.Clear();
        }
    }
}
