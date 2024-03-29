﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressionPanelScript : MonoBehaviour, IMenuPanel
{
    [SerializeField]
    private float _sliderScoreGainPerSecond = 2000;

    [SerializeField]
    private List<RewardListElement> _rewardButtons;

    //==========================================================================================
    //
    //==========================================================================================

    private MenuScript _menu;

    private CanvasGroup _canvasGroup;
    private AudioSource _audioSource;
    private CanvasGroup _loadingPanelCanvasGroup;

    private Text _lastSessionScoreText;
    private Text _bestSessionScoreText;
    private Text _totalScoreText;

    private Text _currentLevelText;
    private Text _nextLevelText;
    private Slider _levelSlider;

    private GameObject _challengeCompleted;
    private Text _challengeScoreText;
    private Text _challengeDescriptionText;

    private Scrollbar _rewardScrollbar;

    private bool _active = false;
    private bool _updated = false;
    private bool _updating = false;

    private int _currentLevel;
    private float _nextLevelRequiredScore;
    private float _currentTotalScore;
    private float _currentLevelScore;
    private float _targetTotalScore;

    private bool _challengeChanged = false;

    //==========================================================================================
    //
    //==========================================================================================

    void Awake()
    {
        _menu = this.transform.parent.GetComponent<MenuScript>();

        _canvasGroup = GetComponent<CanvasGroup>();
        _audioSource = GetComponent<AudioSource>();
        _loadingPanelCanvasGroup = this.transform.Find("PanelLoading").GetComponent<CanvasGroup>();

        _lastSessionScoreText = this.transform.Find("LevelPanel/LastSessionScoreText").GetComponent<Text>();
        _bestSessionScoreText = this.transform.Find("LevelPanel/BestSessionScoreText").GetComponent<Text>();
        _totalScoreText = this.transform.Find("LevelPanel/TotalScoreText").GetComponent<Text>();

        _currentLevelText = this.transform.Find("LevelPanel/CurrentLevelText").GetComponent<Text>();
        _nextLevelText = this.transform.Find("LevelPanel/NextLevelText").GetComponent<Text>();
        _levelSlider = this.transform.Find("LevelPanel/Slider").GetComponent<Slider>();

        _challengeCompleted = this.transform.Find("ChallengePanel/UpperLine/ChallengeCompleted").gameObject;
        _challengeScoreText = this.transform.Find("ChallengePanel/UpperLine/ChallengeScoreText").GetComponent<Text>();
        _challengeDescriptionText = this.transform.Find("ChallengePanel/ChallengeDescriptionText").GetComponent<Text>();

        _rewardScrollbar = this.transform.Find("RewardPanel/Scroll View/Scrollbar Vertical").GetComponent<Scrollbar>();

        _canvasGroup.alpha = 0;
        _canvasGroup.interactable = false;
        _canvasGroup.blocksRaycasts = false;
    }

    void Update()
    {
        if (_updating)
        {
            bool updatingDone = false;
            float scoreGain = _sliderScoreGainPerSecond * (_nextLevelRequiredScore / _sliderScoreGainPerSecond) * Time.deltaTime;

            _currentTotalScore += scoreGain;

            if (_currentTotalScore > _targetTotalScore)
            {
                scoreGain -= (_currentTotalScore - _targetTotalScore);
                _currentTotalScore = _targetTotalScore;
                updatingDone = true;
            }
            else if (_currentTotalScore == _targetTotalScore)
            {
                updatingDone = true;
            }

            _currentLevelScore += scoreGain;

            if (_currentLevelScore >= _nextLevelRequiredScore)
            {
                _currentLevelScore -= _nextLevelRequiredScore;
                _currentLevel++;
                _nextLevelRequiredScore = GameManagerScript.Instance.GetLevelRequirement(_currentLevel);

                UpdateLevelText(_currentLevel);
                UpdateRewardButtons(_currentLevel);
                _audioSource.Play();
            }

            if (_currentLevel == GameManagerScript.Instance.MaxLevel)
            {
                _levelSlider.value = 1;
            }
            else
            {
                float sliderFill = _currentLevelScore / _nextLevelRequiredScore;
                //Debug.Log("slider update: current level score = " + _currentLevelScore + ";  next level = " + _nextLevelRequiredScore + ";  slider fill = " + sliderFill);
                _levelSlider.value = sliderFill;
            }

            if (updatingDone)
            {
                _updated = true;
                _updating = false;

                if(_currentLevel >= 27)
                {
                    _rewardScrollbar.value = 0;
                }
                else
                {
                    _rewardScrollbar.value = 1;
                }
            }
        }
    }

    //==========================================================================================
    //
    //==========================================================================================

    public void OnEnter()
    {
        if (!_active)
        {
            //**************************************************
            //show menu
            _active = true;
            _canvasGroup.alpha = 1;
            _canvasGroup.interactable = true;
            _canvasGroup.blocksRaycasts = true;

            //**************************************************
            //update score texts
            _lastSessionScoreText.text = "Last Stage Score: " + GameManagerScript.Instance.SessionScore;
            _bestSessionScoreText.text = "Best Stage Score: " + GameManagerScript.Instance.BestSessionScore;
            _totalScoreText.text = "Cumulated Score: " + GameManagerScript.Instance.TotalScore;

            //**************************************************
            //update score slider
            _currentLevel = GameManagerScript.Instance.ComputeLevel(GameManagerScript.Instance.OldTotalScore);

            if (!_updated && GameManagerScript.Instance.SessionScore > 0 && _currentLevel < GameManagerScript.Instance.MaxLevel)
            {
                _updating = true;

                _currentLevel = GameManagerScript.Instance.ComputeLevel(GameManagerScript.Instance.OldTotalScore);
                _currentTotalScore = GameManagerScript.Instance.OldTotalScore;
                _currentLevelScore = GameManagerScript.Instance.OldTotalScore;

                for (int i = 0; i < _currentLevel; i++)
                {
                    _currentLevelScore -= GameManagerScript.Instance.GetLevelRequirement(i);
                }

                _nextLevelRequiredScore = GameManagerScript.Instance.GetLevelRequirement(_currentLevel);
                _targetTotalScore = GameManagerScript.Instance.TotalScore;

                float initialSliderFill = _currentLevelScore / _nextLevelRequiredScore;
                _levelSlider.value = initialSliderFill;
            }
            else
            {
                _currentLevel = GameManagerScript.Instance.ComputeLevel(GameManagerScript.Instance.TotalScore);
                _nextLevelRequiredScore = GameManagerScript.Instance.GetLevelRequirement(_currentLevel);

                if (_currentLevel == GameManagerScript.Instance.MaxLevel)
                {
                    _levelSlider.value = 1;
                }
                else
                {
                    _currentLevelScore = GameManagerScript.Instance.TotalScore;

                    for (int i = 0; i < _currentLevel; i++)
                    {
                        _currentLevelScore -= GameManagerScript.Instance.GetLevelRequirement(i);
                    }

                    float sliderFill = _currentLevelScore / _nextLevelRequiredScore;
                    Debug.Log("slider update: current level score = " + _currentLevelScore + ";  next level = " + _nextLevelRequiredScore + ";  slider fill = " + sliderFill);
                    _levelSlider.value = sliderFill;
                }

                if (_currentLevel >= 27)
                {
                    _rewardScrollbar.value = 0;
                }
                else
                {
                    _rewardScrollbar.value = 1;
                }
            }

            UpdateLevelText(_currentLevel);
            UpdateRewardButtons(_currentLevel);

            //**************************************************
            //update challenge panel
            UpdateChallengePanel();
        }
    }

    public void OnExit()
    {
        if (_active)
        {
            //**************************************************
            //hide menu
            _active = false;
            _canvasGroup.alpha = 0;
            _canvasGroup.interactable = false;
            _canvasGroup.blocksRaycasts = false;

            //**************************************************
            //interrupt updating
            if (_updating)
            {
                _updated = true;
                _updating = false;
            }

            //**************************************************
            //generate new challenge
            if (GameManagerScript.Instance.CurrentChallenge.Completed)
            {
                GameManagerScript.Instance.ChangeChallenge();
            }

            //**************************************************
            //deactivate challenge completed stuff
            _challengeCompleted.SetActive(false);
        }
    }

    //==========================================================================================
    //
    //==========================================================================================

    public void OnButtonBack()
    {
        _menu.SwitchPanel(_menu.LevelSelectionPanel);
    }

    public void ShowStory(GameObject toShow)
    {
        toShow.SetActive(true);
    }

    public void OnChangeChallengeButton(Button button)
    {
        if (!_challengeChanged)
        {
            GameManagerScript.Instance.ChangeChallenge();
            _challengeCompleted.SetActive(false);
            UpdateChallengePanel();
            button.interactable = false;
            _challengeChanged = true;
        }
    }

    public void OnRestartButton()
    {
        _canvasGroup.interactable = false;
        _loadingPanelCanvasGroup.alpha = 1;

        GameManagerScript.Instance.StartGame();
    }

    //==========================================================================================
    //
    //==========================================================================================

    private void UpdateLevelText(int currentLevel)
    {
        if (currentLevel >= GameManagerScript.Instance.MaxLevel - 1)
        {
            _currentLevelText.text = "Lvl " + (GameManagerScript.Instance.MaxLevel);

            _nextLevelText.text = "Max Level";
        }
        else
        {
            _currentLevelText.text = "Lvl " + (currentLevel + 1);

            _nextLevelText.text = "Lvl " + (currentLevel + 2);
        }
    }

    private void UpdateRewardButtons(int currentLevel)
    {
        ColorBlock block = _rewardButtons[0].button.colors;
        block.disabledColor = new Color(1, 1, 1, 0.9f);

        foreach (RewardListElement element in _rewardButtons)
        {
            if (currentLevel + 1 >= element.level)
            {
                element.button.colors = block;
                element.button.interactable = true;
            }
            else
            {
                element.button.interactable = false;
            }
        }
    }

    private void UpdateChallengePanel()
    {
        Challenge challenge = GameManagerScript.Instance.CurrentChallenge;

        _challengeScoreText.text = "+ " + challenge.Score + " PTS";
        _challengeDescriptionText.text = challenge.Description;

        if (challenge.Completed)
        {
            _challengeCompleted.SetActive(true);
        }
    }
}

//---------------------------------------------------------------------------------------
//---------------------------------------------------------------------------------------
//---------------------------------------------------------------------------------------

[System.Serializable]
public class RewardListElement
{
    public int level;
    public Button button;
}