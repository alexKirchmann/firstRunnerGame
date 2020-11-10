using UnityEngine;
using Image = UnityEngine.UI.Image;

public class PauseManager : MonoBehaviour {
    private bool _isPaused;
    public GameObject player;
    public GameObject pauseScreen;
    public GameObject sceneGameManager;
    public Sprite pauseButton;
    public Sprite playButton;
    
    void Update() {
        #region KeyboardInput

        if (Application.platform == RuntimePlatform.WindowsEditor ||
            Application.platform == RuntimePlatform.WindowsPlayer) {
            
            if (Input.GetKeyUp(KeyCode.P)) {
                switch (_isPaused) {
                    case false:
                        Pause(true);
                        break;
                    case true:
                        Pause(false);
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
                                Pause(true);
                                break;
                            case true:
                                Pause(false);
                                break;
                        }
                    }
                }
            }

            if (Input.GetKeyUp(KeyCode.Escape)) {
                switch (_isPaused) {
                    case false:
                        Pause(true);
                        break;
                    case true:
                        player.GetComponent<Player>().SaveScore();
                        sceneGameManager.GetComponent<SceneGameManager>().scene = "Main Menu";
                        sceneGameManager.GetComponent<SceneGameManager>().fadeAnimator.SetTrigger("fadeOut");
                        Time.timeScale = 1;
                        break;
                }
            }
        }
        
        #endregion
    }
    
    public void OnApplicationFocus(bool hasFocus) {
        if (!hasFocus) {
            Pause(true);
        }
    }

    public void Pause(bool pauseActive) {
        pauseScreen.SetActive(pauseActive);
        player.GetComponent<Player>().enabled = !pauseActive;
        switch (pauseActive) {
            case true : 
                Time.timeScale = 0; 
                GetComponent<Image>().sprite = playButton; 
                break;
            case false : 
                Time.timeScale = 1; 
                GetComponent<Image>().sprite = pauseButton; 
                break;
        }
        _isPaused = pauseActive;
    }
}
