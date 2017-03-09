using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundSpriteScript : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        if (GameManagerScript.Instance.UseBackgroundSprite)
        {
            SpriteRenderer renderer = GetComponent<SpriteRenderer>();

            renderer.sprite = GameManagerScript.Instance.BackgroundSprite;

            Material mat = GameManagerScript.Instance.BackgroundMaterial;

            if (mat != null)
            {
                renderer.material = mat;
            }
        }
    }
}
