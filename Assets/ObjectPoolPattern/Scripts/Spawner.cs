using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public ObjectPooler pooledPrefab;

    private float spawnTimer;

    private float spawnInterval = 0.1f;



    void Start()
    {
        spawnTimer = Mathf.Infinity;

        if (pooledPrefab == null)
        {
            Debug.LogError("Need a pool object");
        }
    }



    void Update()
    {

        if (Input.GetKey(KeyCode.Space) && spawnTimer > spawnInterval)
        {
            spawnTimer = 0f;

            GameObject newObject = pooledPrefab.GetObject();

            if (newObject != null)
            {
                newObject.SetActive(true);

                newObject.transform.forward = transform.forward;

                newObject.transform.position = transform.position ;
            }
            else
            {
                Debug.Log("Couldn't find a new object");
            }
        }

        spawnTimer += Time.deltaTime;
    }

}
