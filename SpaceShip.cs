using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SpaceShip : SpeedUpObject {
    public GameObject scoreUI;
    public GameObject engineParticles;

    private GameObject canvas;
    private Player trigger;
    private bool isTriggered;

    private void Start() {
        var engPart = Instantiate(engineParticles, engineParticles.transform.position, Quaternion.identity);
        engPart.transform.SetParent(transform, false);
        
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
            transform.position = new Vector3(player.transform.position.x + 1f, player.transform.position.y, -1);
        }
    }

    private void OnTriggerEnter2D (Collider2D other) {
        if (other.CompareTag("Player")) {
            speed = 0;
            trigger = other.GetComponent<Player>();
            isTriggered = true;
            other.GetComponent<Animator>().SetBool("isEating", true);
            other.GetComponent<Player>().score += 1;
            scoreUI.GetComponent<Text>().text = "+1";
            var sUI = Instantiate(scoreUI, scoreUI.transform.position, Quaternion.identity);
            sUI.transform.SetParent(canvas.transform, false);

            StartCoroutine(destroy());
        }
    }

    IEnumerator destroy () {
        yield return new WaitForSeconds(0.22f);
        Destroy(gameObject);
        
    }
}
