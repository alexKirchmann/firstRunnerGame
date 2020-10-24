using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {
    private Vector2 targetPos;

    public float yIncrement;
    public float speed;
    public float maxY;
    public float minY;

    public short health = 3;
    
    private void Start() {
        targetPos = new Vector2(transform.position.x, transform.position.y);
    }

    void Update() {
        if (health <= 0) {
            SceneManager.LoadScene("GameOver");
        }
        transform.position = Vector2.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);

        if ((Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S)) && transform.position.y >  minY) {
            targetPos.y -= yIncrement;
        }
        else if ((Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W)) && transform.position.y < maxY) {
            targetPos.y += yIncrement;
        }
    }
}
