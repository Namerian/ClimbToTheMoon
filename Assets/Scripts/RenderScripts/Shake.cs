using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Shake : MonoBehaviour {

    public bool shaking;
    public float shakePower;
    Vector2 originalPos;

	// Use this for initialization
	void Start ()
    {
        originalPos = transform.position;
	}
	
	// Update is called once per frame
	void Update ()
    {
        originalPos = transform.parent.position;

        if (shaking)
        {
            transform.position = new Vector2(originalPos.x + Random.Range(-shakePower, shakePower), originalPos.y + Random.Range(-shakePower, shakePower));             
        }
	}
}
