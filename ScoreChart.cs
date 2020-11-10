using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScoreChart : MonoBehaviour {
    private Text chart;
    private string _scene;
    public GameObject sceneGameManager;

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
    
    public void Update() {
        if (Application.platform == RuntimePlatform.Android) {

            if (Input.GetKey(KeyCode.Escape)) {
                sceneGameManager.GetComponent<SceneGameManager>().scene = "Main Menu";
                sceneGameManager.GetComponent<SceneGameManager>().fadeAnimator.SetTrigger("fadeOut");
            }
        }
    }
}
