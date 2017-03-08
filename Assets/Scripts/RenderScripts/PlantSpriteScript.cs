using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantSpriteScript : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        SpriteRenderer renderer = GetComponent<SpriteRenderer>();
        Sprite sprite = GameManagerScript.Instance.PlantSprite;

        if (sprite != null)
        {
            renderer.sprite = sprite;
        }
    }
}
