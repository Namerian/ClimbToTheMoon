using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour {

    public float timer = 1;

	// Use this for initialization
	void Start () {
        Destroy(gameObject, timer);
	}
}
