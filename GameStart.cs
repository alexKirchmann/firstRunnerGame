using UnityEngine;

public class GameStart : MonoBehaviour {
    public GameObject deathSound;
    
    private void Start() {
        Instantiate(deathSound, transform.position, Quaternion.identity);
    }

    public void Update() {
        if (Application.platform == RuntimePlatform.Android) {
            
            if (Input.GetKey(KeyCode.Escape)) {
                AndroidJavaObject activity =
                    new AndroidJavaClass("com.unity3d.player.UnityPlayer").GetStatic<AndroidJavaObject>(
                        "currentActivity");

                activity.Call<bool>("moveTaskToBack", true);
            }
        }
    }
}
