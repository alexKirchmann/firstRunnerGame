
using UnityEngine;

public class BonusShield : MonoBehaviour {
    public GameObject shieldParticles;
    private Animator buttonAnim;
    private GameObject player;

    private void Start() {
        buttonAnim = gameObject.GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update() {
        #region KeyboardInput
        if (Input.GetKeyDown(KeyCode.S)) {
            buttonAnim.SetTrigger("isPressed");
        }
        
        if (Input.GetKeyUp(KeyCode.S)) {
            var shld = Instantiate(shieldParticles, shieldParticles.transform.position, shieldParticles.transform.rotation);
            shld.transform.SetParent(player.transform, false);
            Destroy(gameObject);
        }
        #endregion
        
        #region TouchscreenInput
        if (Input.touchCount > 0) {
            Vector3 touchPosition = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
            Vector2 touchPosition2D = new Vector2(touchPosition.x, touchPosition.y);
            RaycastHit2D hit = Physics2D.Raycast(touchPosition2D, Vector2.zero);

            if (hit.collider != null) {
                if (hit.collider.gameObject.CompareTag("BonusShield")) {
                    buttonAnim.SetTrigger("isPressed");

                    if (Input.GetTouch(0).phase == TouchPhase.Ended || Input.GetTouch(0).phase == TouchPhase.Canceled) {
                        var shld = Instantiate(shieldParticles, shieldParticles.transform.position, shieldParticles.transform.rotation);
                        shld.transform.SetParent(player.transform, false);
                        Destroy(gameObject);
                    }
                }
            } else {
                buttonAnim.ResetTrigger("isPressed");
            }
        }
        #endregion
        
    }
}
