using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackScript : MonoBehaviour {
    public GameObject destroySound;
    public GameObject particleEffect;
    private void OnParticleCollision(GameObject other) {
        if (other.CompareTag("Obstacle")) {
            Instantiate(destroySound, transform.position, Quaternion.identity);
            Instantiate(particleEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
