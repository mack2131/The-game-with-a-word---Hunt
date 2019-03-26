using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuPlay : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
        GetComponent<Button>().onClick.AddListener(Play);
	}

    void Play()
    {
        SceneManager.LoadScene("Prototype Scene");
    }
}
