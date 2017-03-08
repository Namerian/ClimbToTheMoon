using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsPanelScript : MonoBehaviour, IMenuPanel
{
    private MenuScript _menu;

    private CanvasGroup _canvasGroup;

    private bool _active;

    void Awake()
    {
        _menu = this.transform.parent.GetComponent<MenuScript>();
        _canvasGroup = GetComponent<CanvasGroup>();
        _canvasGroup.alpha = 0;
        _canvasGroup.interactable = false;
        _canvasGroup.blocksRaycasts = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnEnter()
    {
        if (!_active)
        {
            _active = true;
            _canvasGroup.alpha = 1;
            _canvasGroup.interactable = true;
            _canvasGroup.blocksRaycasts = true;
        }
    }

    public void OnExit()
    {
        if (_active)
        {
            _active = false;
            _canvasGroup.alpha = 0;
            _canvasGroup.interactable = false;
            _canvasGroup.blocksRaycasts = false;
        }
    }

    public void OnButtonBack()
    {
        _menu.SwitchPanel(_menu.TitlePanel);
    }
}
