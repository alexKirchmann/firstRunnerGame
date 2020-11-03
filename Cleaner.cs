using UnityEngine;

public class Cleaner : MonoBehaviour {
    public float endX;

    void Update() {
        if (transform.position.x <= endX)
            Destroy(gameObject);
        else {
            Destroy(gameObject, 5);
        }
    }
}
