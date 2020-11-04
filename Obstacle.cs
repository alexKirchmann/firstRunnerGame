using UnityEngine;

public class Obstacle : SpeedUpObject {
    public short damage = 1;
    public GameObject particleEffect;
    public GameObject damageSound;
    public GameObject destroySound;
    
    private Animator _cameraAnim;

    private void Start() {
        _cameraAnim = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Animator>();
        Player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    void Update() {
        transform.Translate(Vector2.left * (speed * Time.deltaTime));
        
        CurrentScore = Player.score - (ScoreNeedForSpeed * SpeedInc);
        SpeedUp();
    }

    void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.CompareTag("Player")) {
            Instantiate(damageSound, transform.position, Quaternion.identity);
            _cameraAnim.SetTrigger("collision");
            Instantiate(particleEffect, transform.position, Quaternion.identity);
            other.gameObject.GetComponent<Player>().health -= damage;
            Destroy(gameObject);
        }
    }

    private void OnParticleCollision(GameObject other) {
        if (other.CompareTag("Attack") || other.CompareTag("Shield")) {
            Instantiate(destroySound, transform.position, Quaternion.identity);
            Instantiate(particleEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
