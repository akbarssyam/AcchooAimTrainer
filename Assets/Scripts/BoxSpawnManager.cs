using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxSpawnManager : MonoBehaviour
{
    public static BoxSpawnManager _instance;
    public GameObject boxPrefab;

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }

    public void SpawnNewBox(GameObject go)
    {
        StartCoroutine(_SpawnNewBox(go.transform.position));
    }

    IEnumerator _SpawnNewBox(Vector3 pos)
    {
        yield return new WaitForSeconds(5.0f);

        Instantiate(boxPrefab, pos, Quaternion.identity);
    }
}
