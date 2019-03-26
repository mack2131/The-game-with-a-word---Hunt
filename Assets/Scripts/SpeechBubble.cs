using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using System;

public class SpeechBubble : MonoBehaviour {

    public Text messageText;
    public Sprite tellerIcon;
    public string dialogKey;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        transform.GetChild(0).GetComponent<Image>().sprite = tellerIcon;
        messageText.text = GameObject.FindObjectOfType<ConstructLocalizationDatabase>().GetComponent<ConstructLocalizationDatabase>().FetchDialogByKey(dialogKey);

        CloseBubbles();
    }

    void CloseBubbles()
    {
        if(Input.GetKeyUp(KeyCode.Escape))
        {
            Time.timeScale = 1;
            this.gameObject.SetActive(false);
        }
    }
}
