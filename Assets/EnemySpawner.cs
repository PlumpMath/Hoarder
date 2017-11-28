using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

	public GameObject enemy;

	[SerializeField]
	float defaultSpawnRate = 0.3f;
	[SerializeField]
	float waveDelay = 0.04f;
	[SerializeField]
	float waveSpawnRate = 0.7f;

	bool spawningWave = false;
	int waveCount = 0;
	float maxWaveCount = 5;

	void SpawnEnemy() {
		Instantiate(enemy, transform.position, transform.rotation);
	}

	void WaveSpawn() {
		spawningWave = true;
		waveCount = 0;
	}

	// Use this for initialization
	void Start () {
		InvokeRepeating("SpawnEnemy", 5f, -(defaultSpawnRate - 10));
		InvokeRepeating("WaveSpawn", 5f, -(waveDelay - 10));
		InvokeRepeating("WaveSpawnEnemy", 5f, -(waveSpawnRate - 10));
	}
	
	void WaveSpawnEnemy() {
		if (!spawningWave) {
			return;
		}
		Instantiate(enemy, transform.position, transform.rotation);
		waveCount++;
		if (waveCount > maxWaveCount) {
			maxWaveCount += maxWaveCount * 0.1f;
			spawningWave = false;
		}
	}

	// Update is called once per frame
	void Update () {
		
	}
}
