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
    //private Button _stage2Button;
    //private Button _stage3Button;
    //private Button _char2Button;
    //private Button _char3Button;
    private Outline _char1Outline;
    private Outline _char2Outline;
    private Outline _char3Outline;
    private CanvasGroup _loadingPanelCanvasGroup;
    private List<Outline> _characterButtonOutlines = new List<Outline>();

    private bool _active;

    //==========================================================================================
    //
    //==========================================================================================

    void Awake()
    {
        _menu = this.transform.parent.GetComponent<MenuScript>();

        _canvasGroup = GetComponent<CanvasGroup>();
        //_stage2Button = this.transform.Find("PanelNiveaux/ScrollViewStages/Viewport/Content/ButtonLevel2").GetComponent<Button>();
        //_stage3Button = this.transform.Find("PanelNiveaux/ScrollViewStages/Viewport/Content/ButtonLevel3").GetComponent<Button>();

        //_char1Outline = this.transform.Find("PanelPersos/ScrollViewCharacters/Viewport/Content/ButtonPoulpe").GetComponent<Outline>();
        //_char2Outline = this.transform.Find("PanelPersos/ScrollViewCharacters/Viewport/Content/ButtonChat").GetComponent<Outline>();
        //_char2Button = _char2Outline.GetComponent<Button>();
        //_char3Outline = this.transform.Find("PanelPersos/ScrollViewCharacters/Viewport/Content/ButtonPerso3").GetComponent<Outline>();
        //_char3Button = _char3Outline.GetComponent<Button>();
        foreach (ButtonListElement element in _characterButtons)
        {
            _characterButtonOutlines.Add(element.button.GetComponent<Outline>());
        }

        _loadingPanelCanvasGroup = this.transform.Find("PanelLoading").GetComponent<CanvasGroup>();

        //_stage2Button.interactable = false;
        //_stage3Button.interactable = false;
        //_char2Button.interactable = false;
        //_char3Button.interactable = false;
        //_char1Outline.enabled = false;
        //_char2Outline.enabled = false;
        //_char3Outline.enabled = false;

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

            OnCharacterButton("Poulpe");
            OnCharacterHighlight(_characterButtons[0].button.GetComponent<Outline>());
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

    public void OnLevelButton(int difficulty)
    {
        GameManagerScript.Instance.DifficultyLevel = difficulty;

        _canvasGroup.interactable = false;
        _loadingPanelCanvasGroup.alpha = 1;

        switch (difficulty)
        {
            case 0:
                GameManagerScript.Instance.EnvironmentName = "Ocean";
                break;
            case 1:
                GameManagerScript.Instance.EnvironmentName = "Jungle";
                break;
            case 2:
                GameManagerScript.Instance.EnvironmentName = "Mountain";
                break;
        }

        GameManagerScript.Instance.StartGame();
    }

    public void OnCharacterButton(string name)
    {
        GameManagerScript.Instance.CharacterName = name;
    }

    public void OnCharacterHighlight(Outline outlineToHighlight)
    {
        foreach (Outline outline in _characterButtonOutlines)
        {
            if (outline == outlineToHighlight)
            {
                outline.enabled = true;
            }
            else
            {
                outline.enabled = false;
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
    public int level;
    public Button button;
}
