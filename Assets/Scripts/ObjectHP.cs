using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ObjectHP : MonoBehaviour
{
    public float maxhp = 50;

    public GameObject destroyedVersion;

    private float curhp;

    private void Start()
    {
        curhp = maxhp;
    }

    public void ApplyDamage(float damage)
    {
        // Apply the damage received
        curhp -= damage;

        // Check if the object is destroyed
        DestroyCheck();
    }

    private void DestroyCheck()
    {
        if (curhp <= 0)
        {
            DestroyObject();
        }
    }

    public void DestroyObject()
    {
        StartCoroutine(SpawnNew());
        GameObject dv = Instantiate(destroyedVersion, transform.position, transform.rotation);
        Destroy(dv, 5.0f);

        BoxSpawnManager._instance.SpawnNewBox(gameObject);
        Destroy(gameObject);
    }

    IEnumerator SpawnNew()
    {
        yield return new WaitForSeconds(5.0f);

        Debug.Log("Spawn new Box");
        Instantiate(gameObject, transform.position, transform.rotation);
    }
}
