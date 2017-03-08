using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallColorsScript : MonoBehaviour {

    // Use this for initialization
    void Start()
    {
        SpriteRenderer renderer = GetComponent<SpriteRenderer>();
        Color colour = GameManagerScript.Instance.WallColor;

        SpriteRenderer shadowRenderer = transform.GetChild(0).GetComponent<SpriteRenderer>();
        Color shadowColor = GameManagerScript.Instance.WallShadowColor;

        renderer.color = colour;
        shadowRenderer.color = shadowColor;
    }
}
