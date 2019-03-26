using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    
    [Header("The speed player move with")]
    public float speed;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        LookAtCursor();
        //Moving3D();
        Moving2D();
    }

    void LookAtCursor()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos = Camera.main.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, -2));
        Vector2 dir = new Vector2(mousePos.x - transform.position.x, mousePos.y - transform.position.y);

        transform.up = -dir;
    }

    void Moving3D()
    {
        if (Input.GetKey(KeyCode.W))
            GetComponent<CharacterController>().SimpleMove(Vector3.forward * speed);
        if (Input.GetKey(KeyCode.S))
            GetComponent<CharacterController>().SimpleMove(-Vector3.forward * speed);
        if (Input.GetKey(KeyCode.D))
            GetComponent<CharacterController>().SimpleMove(Vector3.right * speed);
        if (Input.GetKey(KeyCode.A))
            GetComponent<CharacterController>().SimpleMove(-Vector3.right * speed);
    }

    void Moving2D()
    {
        if (Input.GetKey(KeyCode.W))
            GetComponent<CharacterController>().Move(Vector3.up * speed * Time.deltaTime);//GetComponent<CharacterController>().SimpleMove(Vector3.up * speed);
        if (Input.GetKey(KeyCode.S))
            GetComponent<CharacterController>().Move(-Vector3.up * speed * Time.deltaTime);//GetComponent<CharacterController>().SimpleMove(-Vector3.up * speed);
        if (Input.GetKey(KeyCode.D))
            GetComponent<CharacterController>().Move(Vector3.right * speed * Time.deltaTime);//GetComponent<CharacterController>().SimpleMove(Vector3.right* speed);
        if (Input.GetKey(KeyCode.A))
            GetComponent<CharacterController>().Move(-Vector3.right * speed * Time.deltaTime);//GetComponent<CharacterController>().SimpleMove(-Vector3.right * speed);
    }
}
