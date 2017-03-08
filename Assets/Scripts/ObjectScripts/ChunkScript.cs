using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChunkScript : MonoBehaviour
{
    //========================================================
    //
    //========================================================

    private Transform _topTransform;
    private Transform _bottomTransform;

    private Transform TopTransform
    {
        get
        {
            if (_topTransform == null)
            {
                _topTransform = this.transform.FindChild("Top");
            }

            return _topTransform;
        }
    }

    private Transform BottomTransform
    {
        get
        {
            if (_bottomTransform == null)
            {
                _bottomTransform = this.transform.FindChild("Bottom");
            }

            return _bottomTransform;
        }
    }

    //========================================================
    //
    //========================================================

    public Vector3 TopPosition { get { return TopTransform.position; } }

    public Vector3 BottomPosition { get { return BottomTransform.position; } }

    //========================================================
    //
    //========================================================

    // Use this for initialization
    void Start()
    {
        if (this.gameObject.name != "StartChunk")
        {
            AbstractAnchorScript[] anchors = GetComponentsInChildren<AbstractAnchorScript>();

            foreach (AbstractAnchorScript anchor in anchors)
            {
                anchor.Respawn();
            }
        }
    }
}
