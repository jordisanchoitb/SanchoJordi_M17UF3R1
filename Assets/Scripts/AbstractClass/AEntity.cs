using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class AEntity : MonoBehaviour, IHurt
{
    public float maxHealth = 100f;
    public float health = 100f;
    public Slider healthBar;
    public virtual void Hurt(float damage)
    {
        health -= damage;
        healthBar.value = health;
        if (health <= 0)
        {
            this.gameObject.SetActive(false);
        }
    }

    public virtual void OnEnable()
    {
        health = maxHealth;
        healthBar.maxValue = maxHealth;
        healthBar.value = maxHealth;
    }
}
