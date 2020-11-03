using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScoreChart : MonoBehaviour {
    private Text chart;
    
    void Start() {
        chart = GetComponent<Text>();
        chart.text = String.Format("1. {0}\n" +
                                   "2. {1}\n" +
                                   "3. {2}\n" +
                                   "4. {3}\n" +
                                   "5. {4}\n" +
                                   "6. {5}\n" +
                                   "7. {6}\n" +
                                   "8. {7}\n" +
                                   "9. {8}\n" +
                                   "10. {9}\n",
            PlayerPrefs.GetInt("highscore_1", 0), PlayerPrefs.GetInt("highscore_2",0),
            PlayerPrefs.GetInt("highscore_3",0), PlayerPrefs.GetInt("highscore_4",0),
            PlayerPrefs.GetInt("highscore_5",0), PlayerPrefs.GetInt("highscore_6",0),
            PlayerPrefs.GetInt("highscore_7",0), PlayerPrefs.GetInt("highscore_8"),
                PlayerPrefs.GetInt("highscore_9",0), PlayerPrefs.GetInt("highscore_10",0));   
    }

    private void Update() {
        #region KeyboardInput

        if (Input.GetKey(KeyCode.RightArrow)) {
            SceneManager.LoadScene("Main Menu");
        }

        #endregion
        
        #region TouchscreenInput

        if (Input.touchCount > 0) {
            Vector3 touchPosition = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
            Vector2 touchPosition2D = new Vector2(touchPosition.x, touchPosition.y);
            RaycastHit2D hit = Physics2D.Raycast(touchPosition2D, Vector2.zero);

            if (!hit.collider.Equals(null)) {
                if (hit.collider.CompareTag("ButtonRight")) {
                    SceneManager.LoadScene("Main Menu");
                }
            }
        }        

        #endregion
    }
}
