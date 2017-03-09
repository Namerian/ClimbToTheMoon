using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TitlePanelScript : MonoBehaviour, IMenuPanel
{
    [SerializeField]
    private List<TitleObjectListElement> _titleObjects;

    //=====================================================================================
    //
    //=====================================================================================

    private MenuScript _menu;

    private CanvasGroup _canvasGroup;

    private bool _active;

    //=====================================================================================
    //
    //=====================================================================================

    void Awake()
    {
        _menu = this.transform.parent.GetComponent<MenuScript>();
        _canvasGroup = GetComponent<CanvasGroup>();
        _canvasGroup.alpha = 0;
        _canvasGroup.interactable = false;
        _canvasGroup.blocksRaycasts = false;
    }

    void Start()
    {
        GameObject titleObject = null;
        int level = GameManagerScript.Instance.ComputeLevel(GameManagerScript.Instance.TotalScore);

        foreach(TitleObjectListElement element in _titleObjects)
        {
            if(level >= element.level)
            {
                titleObject = element.titleObject;
            }

            element.titleObject.SetActive(false);
        }

        titleObject.SetActive(true);
    }

    //=====================================================================================
    //
    //=====================================================================================

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

    //=====================================================================================
    //
    //=====================================================================================

    public void OnPlayButton()
    {
        _menu.SwitchPanel(_menu.LevelSelectionPanel);
    }

    public void OnSettingsButton()
    {
        _menu.SwitchPanel(_menu.SettingsPanel);
    }

    public void OnExitButton()
    {
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #else
		Application.Quit ();
        #endif
    }
}

[System.Serializable]
public class TitleObjectListElement
{
    public int level;
    public GameObject titleObject;
}