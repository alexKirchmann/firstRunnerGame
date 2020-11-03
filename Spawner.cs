using UnityEngine;
using Random = UnityEngine.Random;

public class Spawner : MonoBehaviour {
    public GameObject[] obstaclePatterns;
    public GameObject[] bonusPatterns;

    private float timeBetweenSpawn = 1;
    private float timeBetweenSpawnBonus = 4;
    public float startTimeBetweenSpawn;
    public float startTimeBetweenSpawnBonus;
    public float decreaseTime;
    public float minTime = 0.65f;

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
