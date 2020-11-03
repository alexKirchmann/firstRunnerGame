using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStart : MonoBehaviour {
    public GameObject deathSound;

    private void Start() {
        Instantiate(deathSound, transform.position, Quaternion.identity);
    }

    private void Update() {
        #region KeyboardInput
        if (Input.GetKey(KeyCode.RightArrow)) {
            SceneManager.LoadScene("Game");
        } else if (Input.GetKey(KeyCode.LeftArrow)) {
            SceneManager.LoadScene("Score");
        }
        #endregion
        
        #region TouchscreenInput
        if (Input.touchCount > 0) {
            Vector3 touchPoint = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
            Vector2 touchPoint2D = new Vector2(touchPoint.x, touchPoint.y);
            RaycastHit2D hit = Physics2D.Raycast(touchPoint2D, Vector2.zero);
            
            if (!hit.collider.Equals(null)) {
                if (hit.collider.CompareTag("ButtonRight")) {
                    SceneManager.LoadScene("Game");
                }
                if (hit.collider.CompareTag("ButtonLeft")) {
                    SceneManager.LoadScene("Score");
                }
            }
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        #endregion
    }
}
