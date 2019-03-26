using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextLocalization : MonoBehaviour {

    public string key;//ключ, по которому ищемся строка

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        GetComponent<Text>().text = GameObject.FindObjectOfType<ConstructLocalizationDatabase>().GetComponent<ConstructLocalizationDatabase>().FetchLocByKey(key);
    }
}
