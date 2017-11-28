using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class timer : MonoBehaviour {

	public float time = -5;
	
	Text txt;

	void Start() {
		txt = GetComponent<Text>();
	}

	// Update is called once per frame
	void Update () {
		time += Time.deltaTime;
		txt.text = "time: " + time;
	}
}
