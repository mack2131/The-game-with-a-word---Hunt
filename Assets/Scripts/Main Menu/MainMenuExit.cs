using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuExit : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
        GetComponent<Button>().onClick.AddListener(Exit);
	}
	
	void Exit()
    {
        Application.Quit();
    }
}
