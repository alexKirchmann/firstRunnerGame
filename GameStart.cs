using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameStart : MonoBehaviour {
    public GameObject deathSound;
    
    private void Start() {
        Instantiate(deathSound, transform.position, Quaternion.identity);
    }
}
