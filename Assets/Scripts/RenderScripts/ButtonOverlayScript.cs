using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonOverlayScript : MonoBehaviour
{
    private Button _button;
    private Image _image;
    private bool _isInteractable;

    void Awake()
    {
        _button = this.transform.parent.GetComponent<Button>();
        _image = GetComponent<Image>();

        _isInteractable = true;
        _image.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(_isInteractable && !_button.interactable)
        {
            _isInteractable = false;
            _image.enabled = true;
        }
        else if(!_isInteractable && _button.interactable)
        {
            _isInteractable = true;
            _image.enabled = false;
        }
    }
}
