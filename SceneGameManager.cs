using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneGameManager : MonoBehaviour {
    private Animator _fadeAnimator;
    private string _scene;
    public string sceneLeft;
    public string sceneRight;

    private void Start() {
        _fadeAnimator = GetComponent<Animator>();
    }

    private void Update() {
        #region KeyboardInput

        if (Input.GetKey(KeyCode.RightArrow) && !GameObject.FindGameObjectWithTag("ButtonRight").Equals(null)) {
            _scene = sceneRight;
            _fadeAnimator.SetTrigger("fadeOut");
        }
        else if (Input.GetKey(KeyCode.LeftArrow) && !GameObject.FindGameObjectWithTag("ButtonLeft").Equals(null)) {
            _scene = sceneLeft;
            _fadeAnimator.SetTrigger("fadeOut");
        }

        #endregion

        #region TouchscreenInput

        if (Input.touchCount > 0) {
            Vector3 touchPoint = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
            Vector2 touchPoint2D = new Vector2(touchPoint.x, touchPoint.y);
            RaycastHit2D hit = Physics2D.Raycast(touchPoint2D, Vector2.zero);

            if (!hit.collider.Equals(null)) {
                if (hit.collider.CompareTag("ButtonRight")) {
                    _scene = sceneLeft;
                    _fadeAnimator.SetTrigger("fadeOut");
                }

                if (hit.collider.CompareTag("ButtonLeft")) {
                    _scene = sceneRight;
                    _fadeAnimator.SetTrigger("fadeOut");
                }
            }

            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        #endregion
    }

    public void OnFadeComplete() {
        SceneManager.LoadScene(_scene);
    }
}
