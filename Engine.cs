using UnityEngine;

public class Engine : SpeedUpObject {
    private void Start() {
        Player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    void Update() {
        transform.Translate(Vector2.left * (speed * Time.deltaTime));
        
        CurrentScore = Player.score - (ScoreNeedForSpeed * SpeedInc);
        SpeedUp();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        Destroy(gameObject);
    }
}
