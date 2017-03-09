using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmbianceBgScript : MonoBehaviour
{
    // Use this for initialization
    void Start()
    {
        GameObject ambianceBg = GameManagerScript.Instance.AmbianceBackground;

        if (ambianceBg != null)
        {
            Instantiate(ambianceBg, this.transform);
        }
    }
}
