using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPointBonus : MonoBehaviour {
    public GameObject spaceShip;
    public GameObject spaceStation;
    public GameObject moonBase;
    public GameObject planet;
    
    void Start() {
        int rnd = Random.Range(1, 100);
        if (rnd >= 1 && rnd <= 70) {
            Instantiate(spaceShip, transform.position, Quaternion.identity);
        } else if (rnd > 70 && rnd <= 82) {
            Instantiate(spaceStation, transform.position, Quaternion.identity);
        } else if (rnd > 82 && rnd <= 94) {
            Instantiate(moonBase, transform.position, Quaternion.identity);
        } else if (rnd > 94 && rnd <= 100) {
            Instantiate(planet, transform.position, Quaternion.identity);
        }
    }
}
