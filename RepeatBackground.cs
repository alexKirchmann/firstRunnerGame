using UnityEngine;
using UnityEngine.SceneManagement;

public class RepeatBackground : SpeedUpObject {
    public float startX;
    public float endX;

    private void Start() {
        if (SceneManager.GetActiveScene().Equals(SceneManager.GetSceneByName("Game")))
            Player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    void Update() {
        transform.Translate(Vector2.left * (speed * Time.deltaTime));
        
        if (transform.position.x <= endX)
            transform.position = new Vector3(startX, transform.position.y, transform.position.z);

        if (SceneManager.GetActiveScene().Equals(SceneManager.GetSceneByName("Game"))) 
            CurrentScore = Player.score - (ScoreNeedForSpeed * SpeedInc);
        SpeedUp();
    }
}
