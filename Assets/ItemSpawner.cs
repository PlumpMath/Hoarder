using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour {

	[SerializeField]
	GameObject items;

	// Use this for initialization
	void Start () {
		InvokeRepeating("Spawn", 5f, 10f);
	}
	
	void Spawn() {
		Debug.Log("Spawning Items");
		Instantiate(items, transform.position, transform.rotation);
	}
}
