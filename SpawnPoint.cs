using UnityEngine;

public class SpawnPoint : MonoBehaviour {
    public GameObject obstacle;
    
    void Start() {
        Instantiate(obstacle, transform.position, Quaternion.identity);
    }
}
