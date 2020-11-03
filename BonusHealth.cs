
using UnityEngine;
using UnityEngine.UI;

public class BonusHealth : MonoBehaviour {
    public GameObject healthParticles;
    public GameObject healthUI;
    
    private GameObject canvas;
    private GameObject player;
    
    private void Start() {
        canvas = GameObject.FindGameObjectWithTag("Canvas");
        player = GameObject.FindGameObjectWithTag("Player");

        player.GetComponent<Player>().health += 2;
        
        var hUI = Instantiate(healthUI, healthUI.transform.position, Quaternion.identity);
        hUI.transform.SetParent(canvas.transform, false);

        var hlth = Instantiate(healthParticles, healthParticles.transform.position, healthParticles.transform.rotation);
        hlth.transform.SetParent(player.transform, false);
        Destroy(gameObject);
    }
}