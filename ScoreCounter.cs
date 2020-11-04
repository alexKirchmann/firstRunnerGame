using UnityEngine;
using UnityEngine.UI;

public class ScoreCounter : MonoBehaviour {
    public Text scoreUI;
    
    private int _score;

    private void Update() {
        scoreUI.text = _score.ToString();
    }

    private void OnTriggerExit2D (Collider2D other) {
        if (other.CompareTag("Obstacle")) {
            _score++;
        }
    }
} 
