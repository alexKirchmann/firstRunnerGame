using System;
using UnityEngine;

public class Engine : SpeedUpObject {

    private void Start() {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    void Update() {
        transform.Translate(Vector2.left * (speed * Time.deltaTime));
        
        currentScore = player.score - (scoreNeedForSpeed * speedInc);
        SpeedUp();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        Destroy(gameObject);
    }
}
