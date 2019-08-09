using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject groundObject;
    public bool spawnAtCenter = true;

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
        if (spawnAtCenter)
        {
            spawnPos = groundObject.GetComponent<Renderer>().bounds.center;
            spawnPos.y = 0f;
        } else
        {
            Bounds bounds = groundObject.GetComponent<Renderer>().bounds;
            float minX = bounds.center.x - gameObject.transform.localScale.x * bounds.size.x * 0.5f;
            float maxX = bounds.center.x + gameObject.transform.localScale.x * bounds.size.x * 0.5f;
            float minZ = bounds.center.z - gameObject.transform.localScale.z * bounds.size.z * 0.5f;
            float maxZ = bounds.center.z + gameObject.transform.localScale.z * bounds.size.z * 0.5f;

            spawnPos = new Vector3(Random.Range(minX, maxX),
                                   0,
                                   Random.Range(minZ, maxZ));
        }
        GameObject spawn = Instantiate(enemyPrefab, spawnPos, groundObject.transform.rotation);
        spawn.transform.LookAt(Camera.main.transform);

        // Add groundObject to spawned enemy
        MoveRandomly mr = spawn.GetComponent<MoveRandomly>();
        if (mr != null)
        {
            mr.groundObject = groundObject;
        }
    }
}
