using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundSpriteScript : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        SpriteRenderer renderer = GetComponent<SpriteRenderer>();
        Sprite sprite = GameManagerScript.Instance.BackgroundSprite;

        renderer.sprite = sprite;
    }
}
