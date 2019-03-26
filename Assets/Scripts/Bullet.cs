using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public float speed;
    public float damage;

    private float lifetimeCounter;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        transform.position += transform.up * Time.deltaTime * speed;
        lifetimeCounter += Time.deltaTime;
        if (lifetimeCounter >= 30)
            Destroy(this.gameObject);
	}

    void OnCollisionEnter(Collision coll)
    {
        if (coll.collider.GetComponent<Enemy>() != null)
        {
            coll.collider.GetComponent<Enemy>().GetHIt(damage);
            Destroy(this.gameObject);
        }
    }
}
