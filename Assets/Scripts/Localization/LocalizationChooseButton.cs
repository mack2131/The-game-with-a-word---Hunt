using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LocalizationChooseButton : MonoBehaviour {

    public int localizationId;

	// Use this for initialization
	void Start ()
    {
        GetComponent<Button>().onClick.AddListener(SetLocalization);
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    void SetLocalization()
    {
        switch (localizationId)
        {
            case 0:
                {
                    GameObject.FindObjectOfType<ConstructLocalizationDatabase>().GetComponent<ConstructLocalizationDatabase>().localFile = "/StreamingAssets/RU_ru/";
                    GameObject.FindObjectOfType<ConstructLocalizationDatabase>().GetComponent<ConstructLocalizationDatabase>().localizationSet = true;
                    transform.parent.gameObject.SetActive(false);
                    break;
                }
            case 1:
                {
                    GameObject.FindObjectOfType<ConstructLocalizationDatabase>().GetComponent<ConstructLocalizationDatabase>().localFile = "/StreamingAssets/EN_en/";
                    GameObject.FindObjectOfType<ConstructLocalizationDatabase>().GetComponent<ConstructLocalizationDatabase>().localizationSet = true;
                    transform.parent.gameObject.SetActive(false);
                    break;
                }
        }
    }
}
