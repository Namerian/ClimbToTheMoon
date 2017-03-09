using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuScript : MonoBehaviour
{
    [SerializeField]
    private List<SpriteListElement> _backgroundSprites;

    //=====================================================================================
    //
    //=====================================================================================

    private IMenuPanel _currentPanel;

    //=====================================================================================
    //
    //=====================================================================================

    public IMenuPanel TitlePanel { get; private set; }
    public IMenuPanel LevelSelectionPanel { get; private set; }
    public IMenuPanel ProgressionPanel { get; private set; }
    public IMenuPanel SettingsPanel { get; private set; }

    //=====================================================================================
    //
    //=====================================================================================

    void Awake()
    {
        TitlePanel = this.transform.Find("Titre").GetComponent<IMenuPanel>();
        LevelSelectionPanel = this.transform.Find("SelectionNiveau").GetComponent<IMenuPanel>();
        ProgressionPanel = this.transform.Find("Progression").GetComponent<IMenuPanel>();
        SettingsPanel = this.transform.Find("Credits&Settings").GetComponent<IMenuPanel>();
    }

    void Start()
    {
        Sprite backgroundSprite = null;
        int level = GameManagerScript.Instance.ComputeLevel(GameManagerScript.Instance.TotalScore);

        foreach(SpriteListElement element in _backgroundSprites)
        {
            if(level >= element.level)
            {
                backgroundSprite = element.sprite;
            }
        }

        this.transform.Find("BackgroundImage").GetComponent<Image>().sprite = backgroundSprite;

        if (GameManagerScript.Instance.SessionScore != 0)
        {
            SwitchPanel(ProgressionPanel);
        }
        else
        {
            SwitchPanel(TitlePanel);
        }
    }

    //=====================================================================================
    //
    //=====================================================================================

    public void SwitchPanel(IMenuPanel newPanel)
    {
        if (_currentPanel != null)
        {
            _currentPanel.OnExit();
        }

        _currentPanel = newPanel;
        _currentPanel.OnEnter();
    }

    //=====================================================================================
    //
    //=====================================================================================
}

[System.Serializable]
public class SpriteListElement
{
    public int level;
    public Sprite sprite;
}