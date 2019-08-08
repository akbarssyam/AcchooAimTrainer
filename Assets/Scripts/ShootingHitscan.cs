using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ShootingHitscan : MonoBehaviour {
    public float bulletDamageMin = 10;
    public float bulletDamageMax = 20;
    public float fireRate = 4;
    public float impactForceBase = 5f;
    public GameObject hitEffect;
    public ParticleSystem muzzleFlash;

    private Animator anim;
    private AudioSource gunSound;
    private float firePeriod;
    private float nextFire = 0f;
    [SerializeField]
    private bool enableLaserLine = false;
    [SerializeField]
    private LineRenderer laserLine;


    private void Start()
    {
        // Delay between shots
        firePeriod = 1.0f / fireRate;

        // Get animator to manage gun movement
        anim = GetComponent<Animator>();
        gunSound = GetComponent<AudioSource>();
        
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
        if (gunSound != null)
        {
            GetComponent<AudioSource>().Play();
        }

        // Play the muzzle flash
        if (!enableLaserLine)
        {
            muzzleFlash.Play();
        }
        else
        {
            StartCoroutine(EnableLaserLine());
            laserLine.SetPosition(0, laserLine.transform.position);
        }

        // Play the firing animation
        if (anim != null)
        {
            anim.SetTrigger("TriggerAction_PrimaryFire");
        }

        Transform t = Camera.main.transform;
        if (Physics.Raycast(t.position, t.TransformDirection(Vector3.forward), out RaycastHit hit, Mathf.Infinity))
        {
            GameObject go = hit.transform.gameObject;

            // Apply Bullet Damage
            float damage = Mathf.RoundToInt(Random.Range(bulletDamageMin, bulletDamageMax));
            go.SendMessage("ApplyDamage", damage, SendMessageOptions.DontRequireReceiver);

            // Add impact force
            if (hit.rigidbody != null)
            {
                hit.rigidbody.AddForce(-hit.normal * impactForceBase * damage);
            }

            // Instantiate hit effect
            GameObject he = Instantiate(hitEffect, hit.point + hit.normal*0.2f, Quaternion.identity);
            Destroy(he, 1.0f);

            // Set Laserline target to our hit target
            if (enableLaserLine)
            {
                laserLine.SetPosition(1, hit.point);
            }
        }
        else // If the shot doesn't hit anything
        {
            if (enableLaserLine)
            {
                Vector3 rayOrigin = Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0.0f));
                laserLine.SetPosition(1, rayOrigin + (Camera.main.transform.forward * 100f));
            }
        }

    }

    IEnumerator EnableLaserLine()
    {
        // Turn on our line renderer
        laserLine.enabled = true;

        //Wait for .07 seconds
        yield return new WaitForSeconds(firePeriod/2);

        // Deactivate our line renderer after waiting
        laserLine.enabled = false;
    }
}
