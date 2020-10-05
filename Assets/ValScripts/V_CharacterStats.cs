using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class V_CharacterStats : MonoBehaviour
{
    public int maxhealth = 100;
    public int currentHealth { get; private set; } //any class can get the value only change it in this class
    public int xp { get; private set; }

    public event System.Action<int, int> OnHealthChanged;

    private void Awake()
    {
        currentHealth = maxhealth; //initial value
        xp = 0;
    }

    public void TakeDamage(int damage)
    {
        if (this != null)
        {
            damage = Mathf.Clamp(damage, 0, int.MaxValue); //prevents negative damage values 

            currentHealth -= damage;
            //Debug.Log(transform.name + " takes " + damage + " damage.");

            if (OnHealthChanged != null)
            {
                OnHealthChanged(maxhealth, currentHealth);
            }

            if (currentHealth <= 0)
            {
                Die();
            }
        }
    }

    public void Heal(int healing)
    {
        currentHealth += Mathf.Clamp(healing, 1, maxhealth); //prevents excessive Health

        if (OnHealthChanged != null)
        {
            OnHealthChanged(maxhealth, currentHealth);
        }
    }

    public void gainXP(int _xp) //Gain XP
    {
        xp += _xp;
    }

    public virtual void Die()
    {
        //Die in some way, should be overriden
        // Debug.Log(transform.name + " died.");

    }
}
