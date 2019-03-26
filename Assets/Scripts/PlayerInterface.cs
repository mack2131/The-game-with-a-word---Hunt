using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using System;

public class PlayerInterface : MonoBehaviour {

    public Image healthBar;
    public Text weaponAmmoText;
    public Image reloadImage;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        HealthBar();
        WeaponInfo();
        ReloadWeapon();
	}

    void HealthBar()
    {
        healthBar.fillAmount = GetComponent<Player>().currentHealth / 100;
    }

    void WeaponInfo()
    {
        //                    body sprite            weapon slot             Weapon  
        weaponAmmoText.text = transform.GetChild(0).transform.GetChild(0).transform.GetChild(0).GetComponent<Weapon>().ammoCounter.ToString();
    }

    void ReloadWeapon()
    {
        if (transform.GetChild(0).transform.GetChild(0).transform.GetChild(0).GetComponent<Weapon>().reloading)
        {
            weaponAmmoText.text = "--";

            reloadImage.gameObject.SetActive(true);

            Vector2 pos;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(reloadImage.transform.parent.transform.parent.transform as RectTransform, Input.mousePosition, reloadImage.transform.parent.transform.parent.GetComponent<Canvas>().worldCamera, out pos);
            reloadImage.transform.position = reloadImage.transform.parent.transform.parent.transform.TransformPoint(pos);

            reloadImage.fillAmount += (1 / transform.GetChild(0).transform.GetChild(0).transform.GetChild(0).GetComponent<Weapon>().reloadAmmoTime) * Time.deltaTime;
        }
        else
        {
            reloadImage.fillAmount = 0;
            reloadImage.gameObject.SetActive(false);
        }
    }
}
