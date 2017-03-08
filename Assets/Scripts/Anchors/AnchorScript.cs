using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnchorScript : AbstractAnchorScript
{
    [SerializeField]
    private List<Sprite> _sprites;

    void Start()
    {
        if (_sprites != null && _sprites.Count > 0)
        {
            this.transform.Find("AnchorSprite").GetComponent<SpriteRenderer>().sprite = _sprites[UnityEngine.Random.Range(0, _sprites.Count - 1)];
        }
    }

    public override void Respawn()
    {
        GameObject go = Instantiate<GameObject>(Resources.Load<GameObject>("Prefabs/Anchors/Anchor"), this.transform.parent);
        go.transform.position = this.transform.position;
        Destroy(this.gameObject);
    }
}
