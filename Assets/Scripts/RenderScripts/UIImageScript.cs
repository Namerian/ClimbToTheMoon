using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIImageScript : MonoBehaviour {

    void Start()
    {
        Image image = GetComponent<Image>();
        Sprite sprite = GameManagerScript.Instance.UIImage;

        if (sprite != null)
        {
            image.sprite = sprite;
        }
    }
}
