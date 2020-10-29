using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour {
    public GameObject deathSound;

    private void Start() {
        Instantiate(deathSound, transform.position, Quaternion.identity);
    }

    void Update() {
        #region KeyboardInput
        if (Input.GetKey(KeyCode.R)) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        #endregion
        
        #region TouchscreenInput
        if (Input.touchCount > 0) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        #endregion
    }
}
