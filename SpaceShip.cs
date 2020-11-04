using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SpaceShip : SpeedUpObject {
    public GameObject scoreUI;
    public GameObject engineParticles;
    public GameObject screamSound;

    private GameObject _canvas;
    private Player _trigger;
    private bool _isTriggered;

    private void Start() {
        var engPart = Instantiate(engineParticles, engineParticles.transform.position, Quaternion.identity);
        engPart.transform.SetParent(transform, false);
        
        _canvas = GameObject.FindGameObjectWithTag("Canvas");
        Player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }
    
    void Update() {
        transform.Translate(Vector2.left * (speed * Time.deltaTime));

        if (!_isTriggered) {
            CurrentScore = Player.score - (ScoreNeedForSpeed * SpeedInc);
            SpeedUp();
        }
        else if (_isTriggered) {
            transform.position = new Vector3(Player.transform.position.x + 1f, Player.transform.position.y, -1);
        }
    }

    private void OnTriggerEnter2D (Collider2D other) {
        if (other.CompareTag("Player")) {
            speed = 0;
            Instantiate(screamSound, transform.position, Quaternion.identity);
            _trigger = other.GetComponent<Player>();
            _isTriggered = true;
            other.GetComponent<Animator>().SetBool("isEating", true);
            
            other.GetComponent<Player>().score += 1;
            scoreUI.GetComponent<Text>().text = "+1";
            
            var sUI = Instantiate(scoreUI, scoreUI.transform.position, Quaternion.identity);
            sUI.transform.SetParent(_canvas.transform, false);

            StartCoroutine(destroy());
        }
    }

    IEnumerator destroy () {
        yield return new WaitForSeconds(0.22f);
        Destroy(gameObject);
        
    }
}
