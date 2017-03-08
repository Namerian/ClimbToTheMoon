using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuScript : MonoBehaviour
{

    //public float bestScore, totalScore, scoreToAdd;
    //public Text currentLevelText, nextLevelText;
    //public Slider progressionJauge;
    //public float[] levelsXP;
    //public int currentLevel;
    //[SerializeField]
    //private GameObject activePanel, progressPanel;

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
        //Debug.Log("Menu: SwitchPanel!");

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

    /*public void ShowGameResultPanel() //à appeler quand on retourne à la scène menu après une partie : affiche directement l'écran de progression
    {
        activePanel.SetActive(false);
        progressPanel.SetActive(true);
        activePanel = progressPanel;
    }*/

    /*public void ChangePanel(GameObject panel) //permet de changer d'écran pour naviguer entre les menus (appel via boutons)
    {
        activePanel.SetActive(false);
        panel.SetActive(true);
        activePanel = panel;
    }*/

    //Ci-dessous, test de coroutine pour remplir la jauge d'XP, ne fonctionnait pas parfaitement

    /*
    IEnumerator JaugeFill() 
    {
        float addToJauge = 0;
        float addToJaugeEachFrame = scoreToAdd / 100;

        progressionJauge.maxValue = levelsXP[currentLevel];
        
        while(addToJauge <= scoreToAdd)
        {
            progressionJauge.value += addToJaugeEachFrame;
            addToJauge += addToJaugeEachFrame;
            Debug.Log(addToJauge);

            if(progressionJauge.value >= progressionJauge.maxValue)
            {
                currentLevel += 1;
                currentLevelText.text = "Level " + currentLevel;
                nextLevelText.text = "Level " + (currentLevel + 1);
                progressionJauge.maxValue = levelsXP[currentLevel];
                progressionJauge.value = 0;
            }
            yield return null;
        }
    }
    */

    //=====================================================================================
    //
    //=====================================================================================

    /*public void LoadLevel(int difficulty)
    {
        GameManagerScript.Instance.DifficultyLevel = difficulty;

        switch (difficulty)
        {
            case 0:
                GameManagerScript.Instance.EnvironmentName = "Ocean";
                break;
            case 1:
                GameManagerScript.Instance.EnvironmentName = "Jungle";
                break;
        }

        GameManagerScript.Instance.StartGame();
    }*/

    /*public void ChangeCharacter(string name)
    {
        GameManagerScript.Instance.CharacterName = name;
    }*/
}
