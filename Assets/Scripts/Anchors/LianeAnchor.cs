using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LianeAnchor : AbstractAnchorScript
{

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public override void Respawn()
    {
        GameObject go = Instantiate<GameObject>(Resources.Load<GameObject>("Prefabs/Anchors/LianeAnchor"), this.transform.parent.parent);
        go.transform.position = this.transform.parent.position;

        Destroy(this.transform.parent.gameObject);
    }
}
