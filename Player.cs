using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour {
    private Vector2 targetPos;

    public float yIncrement;
    public float speed;
    public float maxY;
    public float minY;

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
    }

    void Update() {
        scoreUI.text = score.ToString();
        healthUI.text = health.ToString();

        if (health <= 0) {
            gaveOver.SetActive(true);
            Destroy(gameObject);
        }
        
        transform.position = Vector2.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);

        if ((Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S)) && transform.position.y >  minY) {
            Instantiate(movementSound, transform.position, Quaternion.identity);
            targetPos.y -= yIncrement;
        }
        else if ((Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W)) && transform.position.y < maxY) {
            Instantiate(movementSound, transform.position, Quaternion.identity);
            targetPos.y += yIncrement;
        }
    }
}
