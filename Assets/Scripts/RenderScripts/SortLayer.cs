using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SortLayer : MonoBehaviour
{
    [SerializeField]
    string layerName;

    // Use this for initialization
    void Start()
    {
        Renderer renderer = GetComponent<Renderer>();
        renderer.sortingLayerName = layerName;
    }
}
