using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ShootingHitscan : MonoBehaviour {
    public float bulletDamageMin = 10;
    public float bulletDamageMax = 20;
    public float fireRate = 4;
    public GameObject hitEffect;
    public ParticleSystem muzzleFlash;

    private Animator anim;
    private float firePeriod;
    private float nextFire = 0f;


    private void Start()
    {
        // Delay between shots
        firePeriod = 1.0f / fireRate;

        // Get animator to manage gun movement
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time > nextFire + firePeriod)
        {
            Shoot();
            nextFire = Time.time;
        }
    }

    public void Shoot()
    {
        // Play the audio
        GetComponent<AudioSource>().Play();

        // Play the muzzle flash
        muzzleFlash.Play();

        // Play the firing animation
        anim.SetTrigger("TriggerAction_PrimaryFire");

        Transform t = Camera.main.transform;
        if (Physics.Raycast(t.position, t.TransformDirection(Vector3.forward), out RaycastHit hit, Mathf.Infinity))
        {
            GameObject go = hit.transform.gameObject;

            // Apply Bullet Damage
            float damage = Mathf.RoundToInt(Random.Range(bulletDamageMin, bulletDamageMax));
            go.SendMessage("ApplyDamage", damage, SendMessageOptions.DontRequireReceiver);

            // Instantiate hit effect
            GameObject he = Instantiate(hitEffect, hit.point + hit.normal*0.2f, Quaternion.identity);
            Destroy(he, 1.0f);
        }

    }
}
