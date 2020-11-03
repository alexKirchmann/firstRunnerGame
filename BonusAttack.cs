
using UnityEngine;

public class BonusAttack : MonoBehaviour {
    public GameObject attackParticles;
    private Animator buttonAnim;
    private GameObject player;
    
    private void Start() {
        buttonAnim = gameObject.GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update() {
        #region KeyboardInput
        if (Input.GetKeyDown(KeyCode.A)) {
            buttonAnim.SetTrigger("isPressed");
        }
        
        if (Input.GetKeyUp(KeyCode.A)) {
            Instantiate(attackParticles, new Vector2(attackParticles.transform.position.x, player.transform.position.y), attackParticles.transform.rotation);
            Destroy(gameObject);
        }
        #endregion
        
        #region TouchscreenInput
        if (Input.touchCount > 0) {
            Vector3 touchPosition = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
            Vector2 touchPosition2D = new Vector2(touchPosition.x, touchPosition.y);
            RaycastHit2D hit = Physics2D.Raycast(touchPosition2D, Vector2.zero);

            if (hit.collider != null) {

                if (hit.collider.gameObject.CompareTag("BonusAttack")) {
                    buttonAnim.SetTrigger("isPressed");
                    
                    if (Input.GetTouch(0).phase == TouchPhase.Ended || Input.GetTouch(0).phase == TouchPhase.Canceled) {
                        Instantiate(attackParticles, new Vector2(attackParticles.transform.position.x, player.transform.position.y), attackParticles.transform.rotation);
                        gameObject.SetActive(false);
                    }
                }
            }
            else {
                buttonAnim.ResetTrigger("isPressed");
            }
        }
        #endregion
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.CompareTag("BonusAttack")) {
            Destroy(other.gameObject);
        }
    }
}
