using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingTargetSpawnManager : MonoBehaviour
{
    public GameObject shootingTargetPrefab;
    public GameObject groundObject;

    [SerializeField]
    private int spawnNumber = 2;

    // Start is called before the first frame update
    void Start()
    {
        for (int i=0; i < spawnNumber; i++)
        {
            SpawnEnemy();
        }
    }

    public void SpawnEnemy()
    {
        Vector3 spawnPos;
        Bounds bounds = groundObject.GetComponent<Renderer>().bounds;
        float minX = bounds.center.x - gameObject.transform.localScale.x * bounds.size.x * 0.5f;
        float maxX = bounds.center.x + gameObject.transform.localScale.x * bounds.size.x * 0.5f;

        spawnPos = new Vector3(Random.Range(minX, maxX),0,0);

        GameObject spawn = Instantiate(shootingTargetPrefab, spawnPos, groundObject.transform.rotation);
        spawn.transform.LookAt(Camera.main.transform);
    }
}
