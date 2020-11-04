using UnityEngine;

public class RepeatBackground : SpeedUpObject {
    public float startX;
    public float endX;

    private void Start() {
        Player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    void Update() {
        transform.Translate(Vector2.left * (speed * Time.deltaTime));
        
        if (transform.position.x <= endX)
            transform.position = new Vector3(startX, transform.position.y, transform.position.z);
        
        CurrentScore = Player.score - (ScoreNeedForSpeed * SpeedInc);
        SpeedUp();
    }
}
