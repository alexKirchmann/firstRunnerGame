using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBackground : MonoBehaviour {
    public float speed;
    public float startX;
    public float endX;
    
    void Update()
    {
        transform.Translate(Vector2.left * (speed * Time.deltaTime));

        if (transform.position.x <= endX)
            transform.position = new Vector3(startX, transform.position.y, transform.position.z);
    }
}
