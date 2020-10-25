using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreCounter : MonoBehaviour {
    private int score;

    private void OnTriggerExit2D (Collider2D other) {
        if (other.CompareTag("Obstacle")) {
            score++;
        }
    }
}
