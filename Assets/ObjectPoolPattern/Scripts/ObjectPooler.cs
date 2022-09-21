using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    public GameObject pooledPrefab;

    private List<GameObject> poolingObjects = new List<GameObject>();

    private int Initial_Pool_Size = 10;

    public int Max_Pool_Size = 20;


    private void Start()
    {
        if (pooledPrefab == null)
        {
            Debug.LogError("Need a prefab");
        }

        for (int i = 0; i < Initial_Pool_Size; i++)
        {
            GenerateObject();
        }
    }

    private void GenerateObject()
    {
        GameObject newBullet = Instantiate(pooledPrefab, transform);

        newBullet.SetActive(false);

        poolingObjects.Add(newBullet);
    }


    public GameObject GetObject()
    {
        for (int i = 0; i < poolingObjects.Count; i++)
        {
            GameObject thisBullet = poolingObjects[i];

            if (!thisBullet.activeInHierarchy)
            {
                return thisBullet;
            }
        }

        if (poolingObjects.Count < Max_Pool_Size)
        {
            GenerateObject();

            GameObject lastObject = poolingObjects[poolingObjects.Count - 1];

            return lastObject;
        }

        return null;
    }

}
