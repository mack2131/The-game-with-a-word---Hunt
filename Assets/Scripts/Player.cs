using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public float maxHealth;
    public float currentHealth;

    public int[] quests = new int[2];

	// Use this for initialization
	void Start ()
    {
        currentHealth = maxHealth;	
	}
	
	// Update is called once per frame
	void Update ()
    {
        IsDead();
	}

    public void GetHit(float damage)
    {
        currentHealth -= damage;
    }

    bool IsDead()
    {
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            return true;
        }
        else return false;
    }
}
