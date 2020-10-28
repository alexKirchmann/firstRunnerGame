using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPointBonus : MonoBehaviour {
    public GameObject spaceShip;
    public GameObject spaseStation;
    public GameObject moonBase;
    public GameObject planet;
    
    void Start() {
        int rnd = Random.Range(1, 100);
        if (rnd >= 1 && rnd <= 55) {
            Instantiate(spaceShip, transform.position, Quaternion.identity);
        } else if (rnd > 55 && rnd <= 75) {
            Instantiate(spaseStation, transform.position, Quaternion.identity);
        } else if (rnd > 75 && rnd <= 90) {
            Instantiate(moonBase, transform.position, Quaternion.identity);
        } else if (rnd > 90 && rnd <= 100) {
            Instantiate(planet, transform.position, Quaternion.identity);
        }
    }
}
