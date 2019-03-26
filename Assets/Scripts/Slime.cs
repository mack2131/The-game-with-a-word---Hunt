using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : MonoBehaviour {

    public GameObject player;

    public float range;
    public float gloabalRange;
    public float speed;
    public float timeBetweenHits;

    private float timeBetweenHitsCounter;

    // Use this for initialization
    void Start ()
    {
        player = GameObject.FindObjectOfType<Player>().gameObject;
        timeBetweenHitsCounter = timeBetweenHits;
    }
	
	// Update is called once per frame
	void Update ()
    {
        SlimeBehaviour();

    }

    void SlimeBehaviour()
    {
        if (Vector3.Distance(transform.position, player.transform.position) < range)
        {
            Debug.Log("In range");
            Attack();
        }
        else if(IsInGlobalRange())
            MoveToPlayer();
    }

    void MoveToPlayer()
    {
        LookAtPlayer();
        transform.position += transform.up * Time.deltaTime * speed;
    }

    void LookAtPlayer()
    {
        transform.up = new Vector2(player.transform.position.x - transform.position.x, player.transform.position.y - transform.position.y); 
    }

    void Attack()
    {
        timeBetweenHitsCounter += Time.deltaTime;
        if(timeBetweenHitsCounter >= timeBetweenHits)
        {
            player.GetComponent<Player>().GetHit(GetComponent<Enemy>().damage);
            timeBetweenHitsCounter = 0;
        }
    }

    bool IsInGlobalRange()
    {
        if (Vector3.Distance(transform.position, player.transform.position) < 10.0f)
            return true;
        else return false;
    }
}
