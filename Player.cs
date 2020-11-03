using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {
    private Vector2 targetPos;
    private bool isAlive { get; set; }
    private bool isResetting { get; set; }
    
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
    public GameObject gaveOver;
    public GameObject backgroundMusic;
    public GameObject movementSound;
    
    private void Start() {
        targetPos = new Vector2(transform.position.x, transform.position.y);
        Instantiate(backgroundMusic, transform.position, Quaternion.identity);
        isAlive = true;
    }

    void Update() {
        scoreUI.text = score.ToString();
        healthUI.text = health.ToString();

        if (health <= 0) {
            gaveOver.SetActive(true);
            isAlive = false;
            Destroy(gameObject);
        }
        
        transform.position = Vector2.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);

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
        
        if (GetComponent<Animator>().GetBool("isAttacking") && !isResetting) {
            StartCoroutine(resetAnimation(0.4f, "isAttacking"));
        }
    }

    private void Move(float yIncrement) {
        Instantiate(movementSound, transform.position, Quaternion.identity);
        targetPos.y += yIncrement;
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

    IEnumerator resetAnimation(float sec, String trigger) {
        isResetting = true;
        yield return new WaitForSeconds(sec);
        GetComponent<Animator>().SetBool(trigger, false);
        isResetting = false;
    }
}
