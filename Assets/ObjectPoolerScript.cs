using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolerScript : MonoBehaviour
{
    public static ObjectPoolerScript Instance;

    void Awake()
    {
        Instance = this;
    }


    private Dictionary<int, Queue<GameObject>> pool = new Dictionary<int, Queue<GameObject>>();

    public void SetupPool(GameObject prefab, int size)
    {
        int objectId = prefab.GetInstanceID();

        if (pool.ContainsKey(objectId))
            return;

        pool.Add(objectId, new Queue<GameObject>());

        for (int i = 0; i < size; i++)
        {
            GameObject obj = Instantiate(prefab, transform);
            obj.SetActive(false);
            pool[objectId].Enqueue(obj);

        }



    }


    public GameObject SpawnObject(GameObject objectToSpawn, Vector3 position)
    {
        int objectId = objectToSpawn.GetInstanceID();

        if (!pool.ContainsKey(objectId))
            return null;

        GameObject obj = pool[objectId].Dequeue();
        obj.SetActive(true);
        obj.transform.position = position;

        pool[objectId].Enqueue(obj);

        return obj;
    }
}
