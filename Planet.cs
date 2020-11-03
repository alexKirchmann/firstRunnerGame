using System;
using System.Collections;
using UnityEngine;

public class Planet : SpeedUpObject {
    public GameObject bonus;
    private Player trigger;
    private bool isTriggered;
    private Player player;


    private void Start() {
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
            other.GetComponent<Player>().score += 10;
            Instantiate(bonus, bonus.transform.position, Quaternion.identity);
            StartCoroutine(destroy());
        }
    }

    IEnumerator destroy () {
        yield return new WaitForSeconds(0.22f);
        Destroy(gameObject);
        
    }
}
