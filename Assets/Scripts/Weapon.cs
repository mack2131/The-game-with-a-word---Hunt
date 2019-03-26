using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {

    public float damage;
    public float firingRate;
    public int weaponAmmo;
    public float reloadAmmoTime;
    public Transform bulletSpawnPosition;
    public GameObject bulletPrefab;

    private float firingRateCounter;
    public bool reloading;
    public float reloadCounter;
    private GameObject cartridgeHolder;
    public float ammoCounter;

	// Use this for initialization
	void Start ()
    {
        ammoCounter = weaponAmmo;
        cartridgeHolder = new GameObject("Weapon Cartridge Holder");
	}
	
	// Update is called once per frame
	void Update ()
    {
		if(Input.GetMouseButton(0) && !reloading)
        {
            Fire();
        }
        else
        {
            firingRateCounter = 0;
        }

        if (reloading)
            Reload();
        else if (Input.GetKeyUp(KeyCode.R))
            reloading = true;
	}

    void Fire()
    {
        firingRateCounter += Time.deltaTime;
        if (firingRateCounter >= firingRate)
        {
            GameObject bullet = Instantiate(bulletPrefab);
            bullet.transform.SetParent(cartridgeHolder.transform, false);
            bullet.transform.position = bulletSpawnPosition.position;
            bullet.transform.rotation = bulletSpawnPosition.rotation;
            ammoCounter--;
            firingRateCounter = 0;
            if (ammoCounter == 0)
                reloading = true;
        }
    }

    void Reload()
    {
        reloadCounter += Time.deltaTime;
        if(reloadCounter >= reloadAmmoTime)
        {
            ammoCounter = weaponAmmo;
            reloading = false;
            reloadCounter = 0;
        }
    }
}
