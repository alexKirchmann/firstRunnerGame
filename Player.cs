using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {
    public bool isAlive { get; set; }
    
    private Vector2 _targetPos;
    private bool _isResetting;
    
    public float yIncrement;
    public float speed;
    public float maxY;
    public float minY;

    private bool isDraging;
    private Vector2 touchStart, swipeDelta;
    public float minSwipeLenght;
    
    public int score;
    public Text scoreUI;
    public short health = 3;
    public Text healthUI;
    public GameObject gameOver;
    public GameObject backgroundMusic;
    public GameObject movementSound;
    
    private void Start() {
        _targetPos = new Vector2(transform.position.x, transform.position.y);
        Instantiate(backgroundMusic, transform.position, Quaternion.identity);
        isAlive = true;
    }

    void Update() {
        scoreUI.text = score.ToString();
        healthUI.text = health.ToString();

        if (health <= 0) {
            gameOver.SetActive(true);
            isAlive = false;
            Destroy(gameObject);
            SaveScore();
        }
        
        transform.position = Vector2.MoveTowards(transform.position, _targetPos, speed * Time.deltaTime);

        #region KeyboardInput
        if (Input.GetKeyDown(KeyCode.UpArrow) && transform.position.y < maxY) {
            Move(yIncrement);
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow) && transform.position.y > minY) {
            Move(-yIncrement);
        }
        #endregion

        #region TouchscreenInput
        if (Input.touchCount > 0) {
            if (Input.GetTouch(0).phase == TouchPhase.Began) {
                isDraging = true;
                touchStart = Input.GetTouch(0).position;
            }
            else if (Input.GetTouch(0).phase == TouchPhase.Began || Input.GetTouch(0).phase == TouchPhase.Ended) {
                isDraging = false;
                Reset();
            }
        }
        
        swipeDelta = Vector2.zero;
        if (isDraging) {
            if (Input.touchCount > 0) {
                swipeDelta = Input.GetTouch(0).position - touchStart;
            }
        }

        if (swipeDelta.magnitude > minSwipeLenght) {
            if (swipeDelta.y > 0 && transform.position.y < maxY) {
                Move(yIncrement);
            } else if (swipeDelta.y < 0 && transform.position.y > minY) {
                Move(-yIncrement);
            }
            Reset();
        }
        #endregion
        
        if (GetComponent<Animator>().GetBool("isAttacking") && !_isResetting) {
            StartCoroutine(resetAnimation(0.4f, "isAttacking"));
        }
    }

    private void Move(float yIncrement) {
        Instantiate(movementSound, transform.position, Quaternion.identity);
        _targetPos.y += yIncrement;
    }
    
    private void Reset() {
        touchStart = swipeDelta = Vector2.zero;
        isDraging = false;
    }

    private void OnTriggerExit2D (Collider2D other) {
        if (other.CompareTag("BonusObject")) {
            StartCoroutine(resetAnimation(0.30f, "isEating"));
        }
    }

    IEnumerator resetAnimation(float sec, string trigger) {
        _isResetting = true;
        yield return new WaitForSeconds(sec);
        GetComponent<Animator>().SetBool(trigger, false);
        _isResetting = false;
    }

    private void SaveScore() {
        int bestPlace = 0;
        string baseKey = "highscore_";
        
        for (int i = 10; i >= 1; i--) {
             string localKey = baseKey + i;
            
            if (score > PlayerPrefs.GetInt(localKey)) {
                bestPlace = i;
            } 
        }

        
        if (bestPlace != 0) {
            for (int i = 10; i > bestPlace; i--) {
                int prev = PlayerPrefs.GetInt(baseKey + (i-1));
                PlayerPrefs.SetInt(baseKey + i, prev);
                Debug.Log(baseKey + (i - 1));
            }

            PlayerPrefs.SetInt(baseKey + bestPlace, score);
        }
    }
}
