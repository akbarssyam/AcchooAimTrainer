using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    public float damage = 20;
    public float critMul = 2.0f;

    private void OnCollisionEnter(Collision col)
    {
        bool destroy = false;
        if (col.gameObject.CompareTag("Enemy"))
        {
            col.gameObject.GetComponent<EnemyBehaviour>().ApplyDamage(damage);
            destroy = true;
        }
        else if (col.gameObject.CompareTag("Player"))
        {
            col.gameObject.GetComponent<PlayerBehaviour>().ApplyDamage(damage);
            destroy = true;
        }

        if (destroy)
        {
            Destroy(gameObject);
        }
    }
    
}
