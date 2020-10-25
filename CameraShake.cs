using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour {
    public Animator cameraAnim;

    public void cameraShake() {
        cameraAnim.SetTrigger("collision");
    }
}
