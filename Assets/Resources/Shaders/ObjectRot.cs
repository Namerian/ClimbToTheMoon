using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectRot : MonoBehaviour {
    
	// Use this for initialization
	void Start () {
        Renderer rend = GetComponent<Renderer>();
        //Material tmpMat = rend.material;
       // rend.material = new Material(tmpMat);
        rend.material.SetFloat("_objectrotation", transform.rotation.eulerAngles.z/180*Mathf.PI);
        
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
