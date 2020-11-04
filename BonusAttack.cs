
using System;
using UnityEngine;

public class BonusAttack : MonoBehaviour {
    public GameObject attackParticles;
    public GameObject attackSound;
    
    private Animator _buttonAnim;
    private GameObject _player;
    
    private void Start() {
        _buttonAnim = gameObject.GetComponent<Animator>();
        _player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update() {
        if (!_player.GetComponent<Player>().isAlive) {
            Destroy(gameObject);
        }
        
        #region KeyboardInput
        if (Input.GetKeyDown(KeyCode.A)) {
            _buttonAnim.SetTrigger("isPressed");
        }
        
        if (Input.GetKeyUp(KeyCode.A)) {
            Attack();
        }
        #endregion
        
        #region TouchscreenInput
        if (Input.touchCount > 0) {
            Vector3 touchPosition = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
            Vector2 touchPosition2D = new Vector2(touchPosition.x, touchPosition.y);
            RaycastHit2D hit = Physics2D.Raycast(touchPosition2D, Vector2.zero);

            if (!hit.collider.Equals(null)) {

                if (hit.collider.gameObject.CompareTag("BonusAttack")) {
                    _buttonAnim.SetTrigger("isPressed");

                    if (Input.GetTouch(0).phase == TouchPhase.Ended || Input.GetTouch(0).phase == TouchPhase.Canceled) {
                        Attack();
                    }
                }
            }
            else {
                _buttonAnim.ResetTrigger("isPressed");
            }
        }
        #endregion
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.CompareTag("BonusAttack")) {
            Destroy(other.gameObject);
        }
    }

    private void Attack() {
        _player.GetComponent<Animator>().SetBool("isAttacking", true);
        Instantiate(attackSound, transform.position, Quaternion.identity);
        var atck = Instantiate(attackParticles, new Vector2(attackParticles.transform.position.x, attackParticles.transform.position.y),
            attackParticles.transform.rotation);
        atck.transform.SetParent(_player.transform, false);
        Destroy(gameObject);
    }
}
