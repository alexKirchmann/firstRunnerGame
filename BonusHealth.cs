
using UnityEngine;

public class BonusHealth : MonoBehaviour {
    private void Start() {
        GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().health += 2;
        Destroy(gameObject);
    }
}