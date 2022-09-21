using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSpawnedObject : MonoBehaviour
{
    private float bulletSpeed = 500;

    private float deactivationDelay = 2f;

    Rigidbody rb;
   
    private void OnEnable()
    {
        StartCoroutine(WaitAndDestroy(deactivationDelay));
        GetComponent<Rigidbody>().AddForce(Vector3.forward * bulletSpeed* 500 * Time.deltaTime);
    }

    IEnumerator WaitAndDestroy(float deactivationDelay)
    {
      
        yield return new WaitForSeconds(deactivationDelay);
        gameObject.SetActive(false);
    }
    
}
