using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    public float maxhp = 200;
    public TextMeshPro hpText;

    public event Action<float> OnHealthPctChanged = delegate { };

    private float curhp;

    private void Start()
    {
        curhp = maxhp;
    }

    public void ApplyDamage(float damage)
    {
        // Apply the damage received
        curhp -= damage;

        // Check if the enemy is dead
        DestroyCheck();

        // Update the health bar and other UI
        UpdateUI();
    }

    private void DestroyCheck()
    {
        if (curhp <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void UpdateUI()
    {
        hpText.text = curhp.ToString();

        float currentHealthPct = (float)curhp / (float)maxhp;
        OnHealthPctChanged(currentHealthPct);
    }

    private bool isQuitting = false;
    private void OnApplicationQuit()
    {
        isQuitting = true;
    }
    private void OnDestroy()
    {
        if (isQuitting) return;

        GameObject.Find("EnemyManager").GetComponent<EnemySpawnManager>().SpawnEnemy();
    }
}
