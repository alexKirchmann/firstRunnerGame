using UnityEngine;

public class BonusHealth : MonoBehaviour {
    public GameObject healthParticles;
    public GameObject healthUI;
    
    private GameObject _canvas;
    private GameObject _player;
    
    private void Start() {
        _canvas = GameObject.FindGameObjectWithTag("Canvas");
        _player = GameObject.FindGameObjectWithTag("Player");

        _player.GetComponent<Player>().health += 2;
        
        var hUI = Instantiate(healthUI, healthUI.transform.position, Quaternion.identity);
        hUI.transform.SetParent(_canvas.transform, false);

        var hlth = Instantiate(healthParticles, healthParticles.transform.position, healthParticles.transform.rotation);
        hlth.transform.SetParent(_player.transform, false);
        Destroy(gameObject);
    }
}