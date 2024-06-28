using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    private int currentHealth;
    public Stat damage;
    public Stat maxHealth;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth.GetValue();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void TakeDamage (int _damage)
    {
        currentHealth -= _damage;
        if(currentHealth < 0)
        {
            Die();
        }
    }

    private void Die()
    {
        throw new NotImplementedException();
    }
}
