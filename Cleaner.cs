using UnityEngine;

public class Cleaner : MonoBehaviour {
    public float endX;
    public float endTime;

    void Update() {
        if (transform.position.x <= endX)
            Destroy(gameObject);
        else {
            Destroy(gameObject, endTime);
        }
    }
}
