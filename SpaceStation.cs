using System.Collections;
using UnityEngine;

public class SpaceStation : SpeedUpObject {
    public GameObject bonusButton;
    
    private GameObject canvas;
    private Player trigger;
    private bool isTriggered;

    void Start() {
        canvas = GameObject.FindGameObjectWithTag("Canvas");
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    void Update() {
        transform.Translate(Vector2.left * (speed * Time.deltaTime));
        
        if (!isTriggered) {
            currentScore = player.score - (scoreNeedForSpeed * speedInc);
            SpeedUp();
        }
        else if (isTriggered) {
            transform.position = new Vector3(trigger.transform.position.x + 1.5f, transform.position.y, -1);
        }
        
        if (gameObject.transform.position.x < -10) {
            GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>().SetBool("isEating", false);
        }
    }

    private void OnTriggerEnter2D (Collider2D other) {
        if (other.CompareTag("Player")) {
            speed = 0;
            trigger = other.GetComponent<Player>();
            isTriggered = true;
            GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>().SetBool("isEating", true);
            other.GetComponent<Player>().score += 3;
            if (GameObject.FindGameObjectWithTag("BonusShield") == null){
                var button = Instantiate(bonusButton, bonusButton.transform.position, Quaternion.identity);
                button.transform.SetParent(canvas.transform, false);
            }
            StartCoroutine(destroy());
        }
    }

    IEnumerator destroy () {
        yield return new WaitForSeconds(0.25f);
        Destroy(gameObject);
    }
}