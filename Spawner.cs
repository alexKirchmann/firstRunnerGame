using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {
    public GameObject[] obstaclePatterns;

    private float timeBetweenSpawn;
    public float startTimeBetweenSpawn;
    public float decreaseTime;
    public float minTime = 0.65f;

    void Update() {
        if (timeBetweenSpawn <= 0) {
            int rnd = Random.Range(0, obstaclePatterns.Length);
            Instantiate(obstaclePatterns[rnd], transform.position, Quaternion.identity);
            timeBetweenSpawn = startTimeBetweenSpawn;
            if (startTimeBetweenSpawn > minTime) {
                startTimeBetweenSpawn -= decreaseTime;
            }
        }
        else {
            timeBetweenSpawn -= Time.deltaTime;
        }
    }
}
