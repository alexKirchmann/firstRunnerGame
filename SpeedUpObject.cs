using UnityEngine;

public abstract class SpeedUpObject : MonoBehaviour {
    public float speed;

    protected float currentScore;
    protected float scoreNeedForSpeed = 10;
    protected float speedInc;
    protected Player player;

    public void SpeedUp() {
        if (currentScore >= 10) {
            speed += 3;
            speedInc++;
        }
    }
}
