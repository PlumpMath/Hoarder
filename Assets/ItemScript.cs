using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemScript : MonoBehaviour {

	[SerializeField]
	float moveSpeed = 2;

	[SerializeField]
	float xVelocityMultiplyer = 1f;
	[SerializeField]
	float yVelocityMultiplyer = 1f;

	bool locked = false;
	Vector3 lastMousePos;
	bool holding = false;
	Rigidbody2D rb;

	void Start() {
		rb = GetComponent<Rigidbody2D>();
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "hazard") {
			locked = true;
			if (holding) {
				//Enable gravity
				rb.gravityScale = 0.2f;
				//Calculate velocity to give object
				Vector3 delta = Input.mousePosition - lastMousePos;
				Debug.Log(delta.x + "x");
				Debug.Log(delta.y + "y");
				rb.velocity = new Vector3(delta.x * xVelocityMultiplyer, delta.y * yVelocityMultiplyer, 0);
			}
				
		}
		if (other.gameObject.tag == "Enemy") {
			Destroy(this.gameObject);
		}
	}

	void OnMouseDown() {
		
		if (locked) {
			return;
		}
		holding = true;
		//Disable gravity
		rb.gravityScale = 0;
	}
	void OnMouseUp() {
				if (locked) {
			return;
		}
		//Enable gravity
		rb.gravityScale = 0.2f;
		//Calculate velocity to give object
		Vector3 delta = Input.mousePosition - lastMousePos;
		rb.velocity = new Vector3(delta.x * xVelocityMultiplyer, delta.y * yVelocityMultiplyer, 0);
		holding = false; 
	}

	void OnMouseDrag()
	{
				if (locked) {
			return;
		}
		//Get mouse position
        Vector3 mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		mouse.z = 0;

		//Move the object there
		transform.position = Vector3.Lerp(transform.position, mouse, 0.5f);
		lastMousePos = Input.mousePosition;
	}
}
