using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmbianceBgScript : MonoBehaviour
{
    // Use this for initialization
    void Start()
    {
        Instantiate(GameManagerScript.Instance.AmbianceBackground, this.transform);
    }
}
