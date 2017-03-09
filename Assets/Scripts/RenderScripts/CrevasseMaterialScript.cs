using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrevasseMaterialScript : MonoBehaviour
{
    // Use this for initialization
    void Start()
    {
        if (!GameManagerScript.Instance.UseCrevasse)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Renderer rend = GetComponent<Renderer>();
            rend.material.SetVector("_Color", GameManagerScript.Instance.CrevasseColor);
        }
    }
}
