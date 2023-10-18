using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoxLife : MonoBehaviour , IDamagable
{
    [SerializeField] public float maxHealth = 100f;
    private float currentHealth;

    public Slider healthBar;

    public void Update()
    {
        healthBar.value = currentHealth;
    }

    private void Start()
    {
        currentHealth = maxHealth;  // Initialize current health to maximum health
    }

    public void TakeDamage(float damageAmount)
    {
        currentHealth -= damageAmount;

        if (currentHealth <= 0)
        {
            DestroyBox();
        }
    }

    public static event Action BoxDied; //to show in the UI Wrist band
    public void DestroyBox()
    {
        Destroy(gameObject);

        BoxDied?.Invoke(); //delegate call
    }
}
