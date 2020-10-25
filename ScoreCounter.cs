using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCounter : MonoBehaviour {
    private int score;
    public Text scoreUI;

    private void Update() {
        scoreUI.text = score.ToString();
    }

    private void OnTriggerExit2D (Collider2D other) {
        if (other.CompareTag("Obstacle")) {
            score++;
        }
    }
} 
