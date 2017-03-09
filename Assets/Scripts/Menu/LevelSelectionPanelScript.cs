using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelectionPanelScript : MonoBehaviour, IMenuPanel
{
    [SerializeField]
    private List<ButtonListElement> _stageButtons;

    [SerializeField]
    private List<ButtonListElement> _characterButtons;

    //==========================================================================================
    //
    //==========================================================================================

    private MenuScript _menu;

    private CanvasGroup _canvasGroup;
    private CanvasGroup _loadingPanelCanvasGroup;
    private Dictionary<string,Outline> _characterButtonOutlines = new Dictionary<string, Outline>();

    private bool _active;

    //==========================================================================================
    //
    //==========================================================================================

    void Awake()
    {
        _menu = this.transform.parent.GetComponent<MenuScript>();

        _canvasGroup = GetComponent<CanvasGroup>();
        foreach (ButtonListElement element in _characterButtons)
        {
            _characterButtonOutlines.Add(element.name, element.button.GetComponent<Outline>());
        }

        _loadingPanelCanvasGroup = this.transform.Find("PanelLoading").GetComponent<CanvasGroup>();

        _canvasGroup.alpha = 0;
        _canvasGroup.interactable = false;
        _canvasGroup.blocksRaycasts = false;
    }

    //==========================================================================================
    //
    //==========================================================================================

    public void OnEnter()
    {
        if (!_active)
        {
            _active = true;
            _canvasGroup.alpha = 1;
            _canvasGroup.interactable = true;
            _canvasGroup.blocksRaycasts = true;

            int level = GameManagerScript.Instance.ComputeLevel(GameManagerScript.Instance.TotalScore);

            foreach (ButtonListElement element in _stageButtons)
            {
                if (level + 1 >= element.level)
                {
                    element.button.interactable = true;
                }
                else
                {
                    element.button.interactable = false;
                }
            }

            foreach (ButtonListElement element in _characterButtons)
            {
                if (level + 1 >= element.level)
                {
                    element.button.interactable = true;
                }
                else
                {
                    element.button.interactable = false;
                }
            }

            if (GameManagerScript.Instance.CharacterName == null)
            {
                OnCharacterButton("Poulpe");
            }
            else
            {
                OnCharacterButton(GameManagerScript.Instance.CharacterName);
            }
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

    //==========================================================================================
    //
    //==========================================================================================

    public void OnBackButton()
    {
        _menu.SwitchPanel(_menu.TitlePanel);
    }

    public void OnProgressButton()
    {
        _menu.SwitchPanel(_menu.ProgressionPanel);
    }

    public void OnLevelButton(string stageName)
    {
        _canvasGroup.interactable = false;
        _loadingPanelCanvasGroup.alpha = 1;

        GameManagerScript.Instance.EnvironmentName = stageName;

        GameManagerScript.Instance.StartGame();
    }

    public void OnCharacterButton(string name)
    {
        GameManagerScript.Instance.CharacterName = name;

        foreach(KeyValuePair<string,Outline> pair in _characterButtonOutlines)
        {
            if(pair.Key == name)
            {
                pair.Value.enabled = true;
            }
            else
            {
                pair.Value.enabled = false;
            }
        }
    }

    //==========================================================================================
    //
    //==========================================================================================
}

[System.Serializable]
public class ButtonListElement
{
    public string name;
    public int level;
    public Button button;
}
