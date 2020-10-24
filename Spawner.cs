using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {
    public GameObject obstacle;

    private float timeBetweenSpawn;
    public float startTimeBetweenSpawn;
    
    void Start() {
    }

    void Update() {
        if (timeBetweenSpawn <= 0) {
            Instantiate(obstacle, transform.position, Quaternion.identity);
            timeBetweenSpawn = startTimeBetweenSpawn;
        }
        else {
            timeBetweenSpawn -= Time.deltaTime;
        }
    }
}
