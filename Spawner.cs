using UnityEngine;
using Random = UnityEngine.Random;

public class Spawner : MonoBehaviour {
    public GameObject[] obstaclePatterns;
    public GameObject[] bonusPatterns;

    private float _timeBetweenSpawn = 1;
    private float _timeBetweenSpawnBonus = 4;
    
    public float startTimeBetweenSpawn;
    public float startTimeBetweenSpawnBonus;
    public float decreaseTime;
    public float minTime;

    void Update() {
        if (_timeBetweenSpawn <= 0) {
            if (_timeBetweenSpawnBonus <= 0) {
                int rnd = Random.Range(0, bonusPatterns.Length);
                Instantiate(bonusPatterns[rnd], transform.position, Quaternion.identity);
                _timeBetweenSpawnBonus = startTimeBetweenSpawnBonus;
                _timeBetweenSpawn = startTimeBetweenSpawn;
            }
            else {
                int rnd = Random.Range(0, obstaclePatterns.Length);
                Instantiate(obstaclePatterns[rnd], transform.position, Quaternion.identity);
                _timeBetweenSpawn = startTimeBetweenSpawn;

                if (startTimeBetweenSpawn > minTime) {
                    startTimeBetweenSpawn -= decreaseTime;
                }
            }
        } else {
            _timeBetweenSpawnBonus -= Time.deltaTime;
            _timeBetweenSpawn -= Time.deltaTime;
        }
    }
}
