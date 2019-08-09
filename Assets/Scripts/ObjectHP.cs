using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ObjectHP : MonoBehaviour
{
    public float maxhp = 50;

    private float curhp;

    private void Start()
    {
        curhp = maxhp;
    }

    public void ApplyDamage(float damage)
    {
        // Apply the damage received
        curhp -= damage;

        // Check if the object is destroyed
        DestroyCheck();
    }

    private void DestroyCheck()
    {
        if (curhp <= 0)
        {
            Destroy(gameObject);
        }
    }
}
