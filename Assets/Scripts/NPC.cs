using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using System;

public class NPC : MonoBehaviour {

    public Sprite dialogIcon;
    public GameObject player;
    public int questId;
    public string dialogId;
    public string nonQuestDialogId;

    private GameObject bubbles;

	// Use this for initialization
	void Start ()
    { 
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (player == null)
            player = GameObject.FindObjectOfType<Player>().gameObject;

        if(IsNear() && Input.GetMouseButtonUp(1))
        {
            bubbles = GameObject.Find("SB").transform.GetChild(0).gameObject;
            bubbles.SetActive(true);
            bubbles.GetComponent<SpeechBubble>().tellerIcon = dialogIcon;
            bubbles.GetComponent<SpeechBubble>().dialogKey = dialogId;
            Time.timeScale = 0;
        }
	}

    bool IsNear()
    {
        if (Vector3.Distance(transform.position, player.transform.position) < 3.0f)
            return true;
        else return false;
    }

}
