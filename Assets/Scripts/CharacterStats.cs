using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    private int currentHealth;
    public Stat strength;
    public Stat damage;
    public Stat maxHealth;
    // Start is called before the first frame update
    protected virtual void Start()
    {
        currentHealth = maxHealth.GetValue();
    }

    public virtual void DoDamage(CharacterStats _targetStats)
    {
        int totalDamage = damage.GetValue() + strength.GetValue();
        _targetStats.TakeDamage(totalDamage);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public virtual void TakeDamage (int _damage)
    {
        currentHealth -= _damage;
        if(currentHealth < 0)
        {
            Die();
        }
    }

    protected virtual void Die()
    {
    }
}
