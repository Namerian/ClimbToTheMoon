using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrevasseMaterialScript : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        Renderer rend = GetComponent<Renderer>();
        rend.material.SetVector("_Color", GameManagerScript.Instance.CrevasseColor);
        //SpriteRenderer renderer = GetComponent<SpriteRenderer>();
        //Color color = GameManagerScript.Instance.CrevasseColor;

        //renderer.color = color;
    }
}
