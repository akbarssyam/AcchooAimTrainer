using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public bool spawnAtCenter = true;

    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemy();
    }

    public void SpawnEnemy()
    {
        Vector3 spawnPos;
        if (spawnAtCenter)
        {
            spawnPos = new Vector3(0, 0, 10f);
        } else
        {
            float xPos = Random.Range(-19.0f, 19.0f);
            float zPos = Random.Range(1.0f, 19.0f);
            spawnPos = new Vector3(xPos, 0, zPos);
        }
        GameObject spawn = Instantiate(enemyPrefab, spawnPos, Quaternion.identity);
        spawn.transform.LookAt(Camera.main.transform);
    }
}
