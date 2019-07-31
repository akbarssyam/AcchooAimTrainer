using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float bulletSpeed = 150f;
    public float shootingSpeed = 1.0f;

    private void Start()
    {
        StartCoroutine(ShootPeriodically(shootingSpeed));
    }

    IEnumerator ShootPeriodically(float t)
    {
        while (true)
        {
            GameObject clone = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            clone.GetComponent<Rigidbody>().AddForce(transform.forward * bulletSpeed);
            yield return new WaitForSeconds(t);
        }
    }
}
