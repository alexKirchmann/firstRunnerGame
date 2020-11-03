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
        if (rnd >= 1 && rnd <= 70) {
            Instantiate(spaceShip, transform.position, Quaternion.identity);
        } else if (rnd > 70 && rnd <= 80) {
            Instantiate(spaseStation, transform.position, Quaternion.identity);
        } else if (rnd > 80 && rnd <= 90) {
            Instantiate(moonBase, transform.position, Quaternion.identity);
        } else if (rnd > 90 && rnd <= 100) {
            Instantiate(planet, transform.position, Quaternion.identity);
        }
    }
}
