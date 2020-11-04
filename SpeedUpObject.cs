using UnityEngine;

public abstract class SpeedUpObject : MonoBehaviour {
    public float speed;

    protected float CurrentScore;
    protected const float ScoreNeedForSpeed = 10;
    protected float SpeedInc;
    protected Player Player;

    public void SpeedUp() {
        if (CurrentScore >= ScoreNeedForSpeed) {
            speed += 3;
            SpeedInc++;
        }
    }
}
