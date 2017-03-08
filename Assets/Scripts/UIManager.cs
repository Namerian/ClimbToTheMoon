using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class UIManager : MonoBehaviour
{
    //==========================================================================================
    //
    //==========================================================================================

    private static UIManager _instance;

    public static UIManager Instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.LogError("UIManager is not instantiated!");
            }

            return _instance;
        }
    }

    //==========================================================================================
    //
    //==========================================================================================

    public Text scoreText, comboText, addScoreText, altitudeText;
    public Transform faster;
    private float _score;
    public int combo;
    public Color[] comboColors;

    [SerializeField]
    private float _scoreInterval = 0.1f;

    //==========================================================================================
    //
    //==========================================================================================

    public float Score { get { return _score; } }

    //==========================================================================================
    //
    //==========================================================================================

    void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
        else
        {
            Debug.LogError("UIManager has already been instantiated!");
            Destroy(this);
        }
    }

    // Use this for initialization
    void Start()
    {
        Invoke("UpdateScore", _scoreInterval);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        scoreText.text = ((int)_score).ToString();
    }

    //==========================================================================================
    //
    //==========================================================================================

    public void UpdateCombo(int comb)
    {
        if (comb == combo)
        {
            return;
        }

        if (comb > combo)
        {
            comboText.transform.DOShakePosition(0.5f, comb * 2, 10);
        }

        combo = comb;
        comboText.text = "x" + combo;
        comboText.fontSize = (40 + (8 * combo));
        comboText.color = comboColors[combo];
    }

    public void UpdateAltitude(float altitude)
    {
        altitudeText.text = "" + Mathf.Round(altitude) + "m";
    }

    public void Faster()
    {
        Sequence fasterSequence = DOTween.Sequence();
        fasterSequence.Append(faster.DOScaleY(1f, 0.1f));
        fasterSequence.Append(faster.DOScaleY(0.5f, 0.5f));
        fasterSequence.Join(faster.DOShakePosition(1f, 10, 10));
        fasterSequence.Append(faster.DOScaleY(0f, 0.2f));
    }

    public void AddScore(float scoreToAdd)
    {
        StopCoroutine(AddScoreCoroutine(scoreToAdd));
        StartCoroutine(AddScoreCoroutine(scoreToAdd));
    }

    //==========================================================================================
    //
    //==========================================================================================

    private IEnumerator AddScoreCoroutine(float scoreToAdd)
    {
        scoreToAdd *= GameManagerScript.Instance.ScoreMultiplier;
        _score += scoreToAdd;

        addScoreText.text = "+" + (int)scoreToAdd;
        addScoreText.transform.DOScaleY(1f, 0.1f);
        yield return null;

        addScoreText.transform.DOScaleY(0.5f, 0.5f);
        yield return new WaitForSeconds(1);

        addScoreText.transform.DOScaleY(0, 0.5f);
        yield return new WaitForSeconds(0.5f);
    }

    private void UpdateScore()
    {
        _score += combo * GameManagerScript.Instance.ScoreMultiplier;

        Invoke("UpdateScore", _scoreInterval);
    }
}
