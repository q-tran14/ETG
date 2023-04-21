using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ObjectPoolItem
{
    public GameObject objectToPool;
    public int amountToPool = 5;
    public bool willGrow = true;
}

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool SharedInstance;
    public List<ObjectPoolItem> itemsToPool;
    public List<List<GameObject>> pooledObjectsList;

    void Awake()
    {
        SharedInstance = this;
    }

    void Start()
    {
        pooledObjectsList = new List<List<GameObject>>();

        for (int i = 0; i < itemsToPool.Count; i++)
        {
            ObjectPoolItem item = itemsToPool[i];
            List<GameObject> pooledObjects = new List<GameObject>();

            for (int j = 0; j < item.amountToPool; j++)
            {
                GameObject tmp = Instantiate(item.objectToPool);
                tmp.SetActive(false);
                pooledObjects.Add(tmp);
            }

            pooledObjectsList.Add(pooledObjects);
        }
    }

    public GameObject GetPooledObject(GameObject objectToPool)
    {
        for (int i = 0; i < itemsToPool.Count; i++)
        {
            ObjectPoolItem item = itemsToPool[i];

            if (item.objectToPool == objectToPool)
            {
                List<GameObject> pooledObjects = pooledObjectsList[i];

                for (int j = 0; j < pooledObjects.Count; j++)
                {
                    if (!pooledObjects[j].activeInHierarchy)
                    {
                        return pooledObjects[j];
                    }
                }

                if (item.willGrow)
                {
                    GameObject obj = Instantiate(item.objectToPool);
                    obj.SetActive(false);
                    pooledObjects.Add(obj);
                    return obj;
                }
            }
        }
        return null;
    }
}