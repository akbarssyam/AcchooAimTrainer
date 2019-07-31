using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;

    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemy();
    }

    public void SpawnEnemy()
    {
        float xPos = Random.Range(-6.0f, 6.0f);
        float zPos = Random.Range(-6.0f, 6.0f);
        Vector3 spawnPos = new Vector3(xPos, 0, zPos);
        GameObject spawn = Instantiate(enemyPrefab, spawnPos, Quaternion.identity);
        spawn.transform.LookAt(Camera.main.transform);
    }
}
