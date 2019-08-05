using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingProjectile : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float bulletSpeed = 100f;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    public void Shoot()
    {
        GameObject clone = Instantiate(bulletPrefab, Camera.main.transform.position + Camera.main.transform.forward, Quaternion.identity);
        clone.GetComponent<Rigidbody>().AddForce(Camera.main.transform.forward * bulletSpeed);
        Destroy(clone, 5.0f);
    }
}
