using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobSpawner : MonoBehaviour {

    public GameObject spawnMobPrefab;
    public float spawnTime;

    private float spawnTimeCounter;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        Spawn();
	}

    void Spawn()
    {
        spawnTimeCounter += Time.deltaTime;
        if(spawnTimeCounter >= spawnTime)
        {
            GameObject slime = Instantiate(spawnMobPrefab);
            slime.transform.position = transform.position;
            spawnTimeCounter = 0;
        }
    }
}
