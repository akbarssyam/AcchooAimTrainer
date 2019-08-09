using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    private float hp;
    public float maxHp = 200;
    public TextMeshProUGUI hpText;

    private void Start()
    {
        hp = maxHp;
        UpdateUI();
    }

    public void ApplyDamage(float damage)
    {
        // Apply the damage received
        hp -= damage;

        // Check if the enemy is dead
        DestroyCheck();

        // Update the health bar and other UI
        UpdateUI();
    }

    private void DestroyCheck()
    {
        if (hp <= 0)
        {
            hp = maxHp;
        }
    }

    private void UpdateUI()
    {
        if (hpText != null)
            hpText.text = hp.ToString();
    }
}
