using UnityEngine;
using System.Collections;

public class AudioRandomPitcher : MonoBehaviour {

    public float min = 0.8f;
    public float max = 1.2f;

	// Use this for initialization
	void Start ()
    {
        GetComponent<AudioSource>().pitch = Random.Range(min, max);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
