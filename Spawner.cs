﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Spawner : MonoBehaviour {
    public GameObject[] obstaclePatterns;
    public GameObject[] bonusPatterns;

    private float timeBetweenSpawn;
    private float timeBetweenSpawnBonus;
    public float startTimeBetweenSpawn;
    public float startTimeBetweenSpawnBonus;
    public float decreaseTime;
    public float minTime = 0.65f;

    private void Start() {
        timeBetweenSpawn = timeBetweenSpawn;
        timeBetweenSpawnBonus = timeBetweenSpawnBonus;
    }

    void Update() {
        if (timeBetweenSpawn <= 0) {
            if (timeBetweenSpawnBonus <= 0) {
                int rnd = Random.Range(0, bonusPatterns.Length);
                Instantiate(bonusPatterns[rnd], transform.position, Quaternion.identity);
                timeBetweenSpawnBonus = startTimeBetweenSpawnBonus;
                timeBetweenSpawn = startTimeBetweenSpawn;
            }
            else {
                int rnd = Random.Range(0, obstaclePatterns.Length);
                Instantiate(obstaclePatterns[rnd], transform.position, Quaternion.identity);
                timeBetweenSpawn = startTimeBetweenSpawn;

                if (startTimeBetweenSpawn > minTime) {
                    startTimeBetweenSpawn -= decreaseTime;
                }
            }
        } else {
            timeBetweenSpawnBonus -= Time.deltaTime;
            timeBetweenSpawn -= Time.deltaTime;
        }
    }
}
