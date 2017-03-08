using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnchorMaterialScript : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        SpriteRenderer renderer = GetComponent<SpriteRenderer>();
        Material material = GameManagerScript.Instance.AnchorMaterial;

        if (material != null)
        {
            renderer.material = material;
        }
    }
}
