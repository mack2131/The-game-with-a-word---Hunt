using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public float maxHealth;
    public float currentHealth;
    public float damage;

	// Use this for initialization
	void Start ()
    {
        currentHealth = maxHealth;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (IsDead())
            Die();
	}

    public void GetHIt(float damage)
    {
        currentHealth -= damage;
    }

    public bool IsDead()
    {
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            return true;
        }
        else return false;
    }

    void Die()
    {
        Destroy(this.gameObject);
    }
}
