using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    [Header("The target of the camera to look at")]
    public GameObject player;
    public Vector3 direction;

    private float mouseX;
    private float mouseY;
    private float cameraDif;
    private Vector3 worldPos;

    // Use this for initialization
    void Start ()
    {
        cameraDif = transform.position.y - player.transform.position.y;	
	}
	
	// Update is called once per frame
	void Update ()
    {
        Follow();
	}

    void Follow()
    {
        //PlayerLookAtCursor3D();
        //transform.position = new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z);
        transform.position = new Vector3(player.transform.position.x, player.transform.position.y, transform.position.z);
    }

    void PlayerLookAtCursor3D()
    {
        mouseX = Input.mousePosition.x;
        mouseY = Input.mousePosition.y;
        worldPos = GetComponent<Camera>().ScreenToWorldPoint(new Vector3(mouseX, mouseY, cameraDif));
        direction = new Vector3(worldPos.x, worldPos.y, player.transform.position.z);
        player.transform.LookAt(direction);        
    }

    void Borders()
    {

    }
}
