using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyscript : MonoBehaviour {

	[SerializeField]
	float moveSpeed = 1f;

	void Start() {
		InvokeRepeating("CheckIfWon", 10f, 1f);
	}
	
	// Update is called once per frame
	void Update () {
		//Move forwards
		Vector3 pos = transform.position;
		pos.x -= moveSpeed * Time.deltaTime;
		transform.position = pos;
	}

	void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.tag == "Player") {
			Destroy(other.gameObject);
			Invoke("Destroy", 2f);
			transform.GetChild(0).gameObject.SetActive(true);
			GetComponent<SpriteRenderer>().enabled = false;
			GetComponent<PolygonCollider2D>().enabled = false;
		}
	}

	void CheckIfWon() {
		if (transform.position.x < -8.5) {
			Application.Quit();
			Debug.Log("lost!");
		}
	}
	void Destroy() {
		Destroy(gameObject);
	}
}
