using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health
{
    public event Action HealthChanged;

    const int MinHealth = 0;
    const int MaxHealth = 0;

    public int CurrentHealth { get; set; }

    public int MinHealthValue => MinHealth;
    public int MaxHealthValue => MaxHealth;

    public void Increment(int amount)
    {
        CurrentHealth += amount;
        CurrentHealth = Mathf.Clamp(CurrentHealth, MinHealth, MaxHealth);
        UpdateHealth();
    }

    public void Restore()
    {
        CurrentHealth = MaxHealth;
        UpdateHealth();
    }

    public  void UpdateHealth()
    {
        HealthChanged?.Invoke();
    }
}
