using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseManager : MonoBehaviour {
    private bool _isPaused;
    public GameObject player;
    public GameObject pauseScreen;
    public Sprite pauseButton;
    public Sprite playButton;
    
    void Update() {
        #region KeyboardInput

        if (Application.platform == RuntimePlatform.WindowsEditor ||
            Application.platform == RuntimePlatform.WindowsPlayer) {
            
            if (Input.GetKeyUp(KeyCode.P)) {
                switch (_isPaused) {
                    case false:
                        pauseScreen.SetActive(true);
                        player.GetComponent<Player>().enabled = false;
                        Time.timeScale = 0;
                        GetComponent<Image>().sprite = playButton;
                        _isPaused = true;
                        break;
                    case true:
                        pauseScreen.SetActive(false);
                        player.GetComponent<Player>().enabled = true;
                        Time.timeScale = 1;
                        GetComponent<Image>().sprite = pauseButton;
                        _isPaused = false;
                        break;
                }
            }
        }

        #endregion

        #region TouchscreenInput

        if (Application.platform == RuntimePlatform.Android) {

            if (Input.touchCount > 0) {
                Vector3 touchPosition = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
                Vector2 touchPosition2D = new Vector2(touchPosition.x, touchPosition.y);
                RaycastHit2D hit = Physics2D.Raycast(touchPosition2D, Vector2.zero);

                if (hit) {
                    if (hit.collider.gameObject.CompareTag("ButtonPause") &&
                        (Input.GetTouch(0).phase == TouchPhase.Ended ||
                         Input.GetTouch(0).phase == TouchPhase.Canceled)) {
                        switch (_isPaused) {
                            case false:
                                pauseScreen.SetActive(true);
                                player.GetComponent<Player>().enabled = false;
                                Time.timeScale = 0;
                                GetComponent<Image>().sprite = playButton;
                                _isPaused = true;
                                break;
                            case true:
                                pauseScreen.SetActive(false);
                                player.GetComponent<Player>().enabled = true;
                                Time.timeScale = 1;
                                GetComponent<Image>().sprite = pauseButton;
                                _isPaused = false;
                                break;
                        }
                    }
                }
            }

            if (Input.GetKey(KeyCode.Escape)) {
                AndroidJavaObject activity =
                    new AndroidJavaClass("com.unity3d.player.UnityPlayer").GetStatic<AndroidJavaObject>(
                        "currentActivity");
                
                activity.Call<bool>("moveTaskToBack", true);
            }
        }
        
        #endregion
    }
    
    public void OnApplicationFocus(bool hasFocus) {
        if (!hasFocus) {
            pauseScreen.SetActive(true);
            player.GetComponent<Player>().enabled = false;
            Time.timeScale = 0; 
            GetComponent<Image>().sprite = playButton;
            _isPaused = true;
        }
    }
}
