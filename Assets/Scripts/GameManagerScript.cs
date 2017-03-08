using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerScript : MonoBehaviour
{
    //==========================================================================================
    //
    //==========================================================================================

    private static GameManagerScript _instance;

    public static GameManagerScript Instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.LogError("GameManager is not instantiated!");
            }

            return _instance;
        }
    }

    //==========================================================================================
    //
    //==========================================================================================

    [SerializeField]
    private List<CharacterListElement> _characterPrefabs;

    [SerializeField]
    private List<EnvironmentInfo> _environmentInfoList;

    [SerializeField]
    private List<int> _levelExperience;

    [SerializeField]
    private List<float> _challengeScoreMultiplierByLevel;

    [SerializeField]
    private List<ChallengeInfo> _challengeList;

    //==========================================================================================
    //
    //==========================================================================================

    private EnvironmentInfo _environment;

    private Challenge _challenge;

    //==========================================================================================
    //
    //==========================================================================================

    void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            SceneManager.sceneLoaded += this.OnSceneLoaded;

            DontDestroyOnLoad(this.gameObject);

            TotalScore = PlayerPrefs.GetInt("TotalScore");
            BestSessionScore = PlayerPrefs.GetInt("BestSessionScore");

            //*****
            int totalPossibleScore = 0;
            foreach (int x in _levelExperience)
            {
                totalPossibleScore += x;
            }
            if (TotalScore > totalPossibleScore)
            {
                TotalScore = totalPossibleScore;
            }

            //*****
            LoadChallenge();

            //*****
            AmplitudeHelper.AppId = "e42975312282ef47be31ec6af5cb48fc";
            AmplitudeHelper.Instance.FillCustomProperties += FillTrackingProperties;
            AmplitudeHelper.Instance.LogEvent("Start Game");
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    void OnDestroy()
    {
        if (_instance == this)
        {
            PlayerPrefs.SetInt("TotalScore", TotalScore);
            PlayerPrefs.SetInt("BestSessionScore", BestSessionScore);

            AmplitudeHelper.Instance.LogEvent("Exit Game");
        }
    }

    //==========================================================================================
    // Properties
    //==========================================================================================

    public int DifficultyLevel { get; set; }

    public string CharacterName { get; set; }

    public int SessionScore { get; private set; }

    public int BestSessionScore { get; private set; }

    public int TotalScore { get; private set; }

    public int OldTotalScore { get; private set; }

    public int MaxLevel { get { return _levelExperience.Count; } }

    public Challenge CurrentChallenge { get { return _challenge; } }

    //==========================================================================================
    // Environment Properties
    //==========================================================================================

    public string EnvironmentName
    {
        get { return _environment.name; }
        set
        {
            _environment = null;

            foreach (EnvironmentInfo environment in _environmentInfoList)
            {
                if (value == environment.name)
                {
                    _environment = environment;
                    break;
                }
            }

            if (_environment == null)
            {
                Debug.LogError("Could not find an Environment called " + value);
            }
        }
    }

    public bool SpawnRocks { get { return _environment.spawnRocks; } }

    public float MinRockSpawnTimer { get { return _environment.minRockSpawnTimer; } }

    public float MaxRockSpawnTimer { get { return _environment.maxRockSpawnTimer; } }

    public float RockSpawnOffset { get { return _environment.rockSpawnOffset; } }

    public GameObject RockPrefab { get { return _environment.rockPrefab; } }

    public List<GameObject> EnvironmentChunks { get { return _environment.uniqueChunks; } }

    public Sprite BackgroundSprite { get { return _environment.backgroundSprite; } }

    public GameObject AmbianceBackground { get { return _environment.ambiancePrefab; } }

    public Color CrevasseColor { get { return _environment.crevasseColour; } }

    public Color WallColor { get { return _environment.wallColour; } }

    public Color WallShadowColor { get { return _environment.wallShadowColour; } }

    public Material AnchorMaterial { get { return _environment.anchorMaterial; } }

    public Sprite PlantSprite { get { return _environment.plantSprite; } }

    public Sprite UIImage { get { return _environment.uiImage; } }

    //==========================================================================================
    //
    //==========================================================================================

    public void StartGame()
    {
        SessionScore = 0;

        //***************************

        SceneManager.LoadSceneAsync("Scenes/TestLevel");
    }

    public void LoadMenu()
    {
        PlayerCharacterScript player = GameObject.FindObjectOfType<PlayerCharacterScript>();
        Dictionary<string, object> customProperties;

        //**************************************************************
        //Send EventManager StageEnded event
        EventManager.Instance.SendOnStageEndedEvent((int)player.HighestAltitude, GameManagerScript.Instance.CharacterName);

        //**************************************************************
        //Update Score
        SessionScore = (int)UIManager.Instance.Score;

        if (_challenge.Completed)
        {
            SessionScore += _challenge.Score;

            string challengeName = _challenge.Name;
            int challengeLifetime = _challenge.Lifetime;
            int challengeTargetValue = _challenge.X;

            customProperties = new Dictionary<string, object>()
            {
                {"challenge name", challengeName },
                {"challenge lifetime", challengeLifetime },
                {"challenge targetValue", challengeTargetValue }
            };

            AmplitudeHelper.Instance.LogEvent("Challenge completed", customProperties);
        }

        if (SessionScore > BestSessionScore)
        {
            BestSessionScore = SessionScore;
        }

        int oldLevel = ComputeLevel(TotalScore) + 1;
        OldTotalScore = TotalScore;
        TotalScore += SessionScore;
        int newLevel = ComputeLevel(TotalScore) + 1;

        //**************************************************************
        //Clamp Score
        int totalPossibleScore = 0;
        foreach (int x in _levelExperience)
        {
            totalPossibleScore += x;
        }
        if (TotalScore > totalPossibleScore)
        {
            TotalScore = totalPossibleScore;
        }

        //**************************************************************
        // Send Amplitude LevelUp event
        if (newLevel > oldLevel && newLevel % 5 == 0)
        {
            AmplitudeHelper.Instance.LogEvent("lvl " + newLevel + " reached");
        }

        //**************************************************************
        //Update PlayerPrefs
        PlayerPrefs.SetInt("TotalScore", TotalScore);
        PlayerPrefs.SetInt("BestSessionScore", BestSessionScore);

        //**************************************************************
        //Send Amplitude StageEnd event

        customProperties = new Dictionary<string, object>()
        {
            {"Environment", EnvironmentName },
            {"Stage Score", SessionScore },
            {"Altitude", player.HighestAltitude },
            {"Character", CharacterName },
            {"Last Chunk", player.CurrentChunkName }
        };

        AmplitudeHelper.Instance.LogEvent("Stage End", customProperties);

        //**************************************************************
        //Update Challenge PlayerPrefs
        PlayerPrefs.SetInt("ChallengeCurrent", _challenge.Current);

        //**************************************************************
        //Load Menu scene
        SceneManager.LoadSceneAsync("Scenes/Menu");
    }

    public int ComputeLevel(int experience)
    {
        int level = 0;

        for (int i = 0; i < _levelExperience.Count; i++)
        {
            if (experience >= _levelExperience[i])
            {
                level++;
                experience -= _levelExperience[i];
            }
            else
            {
                break;
            }
        }

        return level;
    }

    public int GetLevelRequirement(int level)
    {
        if (level > _levelExperience.Count - 1)
        {
            return int.MaxValue;
        }

        return _levelExperience[level];
    }

    public float GetAccelerationStep(int altitude)
    {
        float acc = -1;

        foreach (AccelerationStepElement element in _environment.accelerationSteps)
        {
            if (altitude >= element.height)
            {
                acc = element.acceleration;
            }
        }

        return acc;
    }

    public void ChangeChallenge()
    {
        string oldChallengeName = _challenge.Name;
        int oldChallengeLifetime = _challenge.Lifetime;
        int oldChallengeTargetValue = _challenge.X;

        CreateChallenge();

        string newChallengeName = _challenge.Name;
        int newChallengeTargetValue = _challenge.X;

        var customProperties = new Dictionary<string, object>()
        {
            {"old challenge name", oldChallengeName },
            {"old challenge lifetime", oldChallengeLifetime },
            {"old challenge targetValue", oldChallengeTargetValue },
            {"new challenge name", newChallengeName },
            {"new challenge targetValue", newChallengeTargetValue }
        };

        AmplitudeHelper.Instance.LogEvent("Challenge changed", customProperties);
    }

    public float GetScoreMultiplier(float altitude)
    {
        float result = 1;

        foreach(AccelerationStepElement element in _environment.accelerationSteps)
        {
            if(altitude >= element.height)
            {
                result = element.scoreMultiplier;
            }
            else
            {
                break;
            }
        }

        return result;
    }

    //==========================================================================================
    //
    //==========================================================================================

    private void OnSceneLoaded(Scene scene, LoadSceneMode loadSceneMode)
    {
        if (this != _instance)
        {
            Debug.LogError("OnSceneLoaded called in wrong GameManager instance!");
            return;
        }

        if (scene.name == "TestLevel")
        {
            int charIndex = 0;

            for (int i = 0; i < _characterPrefabs.Count; i++)
            {
                CharacterListElement element = _characterPrefabs[i];

                if (CharacterName == element.charName)
                {
                    charIndex = i;
                }
            }

            GameObject startChunk = GameObject.Find("StartChunk");
            Rigidbody2D anchor1Rigidbody = startChunk.transform.Find("Anchors/Anchor_1").GetComponent<Rigidbody2D>();
            Rigidbody2D anchor2Rigidbody = startChunk.transform.Find("Anchors/Anchor_2").GetComponent<Rigidbody2D>();

            GameObject character = Instantiate<GameObject>(_characterPrefabs[charIndex].prefab);

            HingeJoint2D charLeftHand = GameObject.Find("Hand1").GetComponent<HingeJoint2D>();
            HingeJoint2D charRightHand = GameObject.Find("Hand2").GetComponent<HingeJoint2D>();

            float charYPos = anchor1Rigidbody.transform.position.y - (character.transform.position.y - charLeftHand.transform.position.y);

            character.transform.position = new Vector3(0, charYPos, 0);
            anchor1Rigidbody.transform.position = charLeftHand.transform.position;
            anchor2Rigidbody.transform.position = charRightHand.transform.position;

            charLeftHand.connectedBody = anchor1Rigidbody;
            charRightHand.connectedBody = anchor2Rigidbody;

            //*****
            EventManager.Instance.SendOnStageStartedEvent();
        }
        else if (scene.name == "Menu")
        {
            Instantiate(Resources.Load("Prefabs/MenuCanvas"));
        }
    }

    private void FillTrackingProperties(Dictionary<string, object> properties)
    {
        properties["Total Score"] = TotalScore;
        properties["Best Session Score"] = BestSessionScore;
    }

    private void LoadChallenge()
    {
        string challengeName = PlayerPrefs.GetString("ChallengeName");

        if (challengeName == "")
        {
            CreateChallenge();
            return;
        }

        int x = PlayerPrefs.GetInt("ChallengeX");
        int current = PlayerPrefs.GetInt("ChallengeCurrent");
        int score = PlayerPrefs.GetInt("ChallengeScore");

        switch (challengeName)
        {
            case "ForeverAltitudeChallenge":
                _challenge = new ForeverAltitudeChallenge(x, score, current);
                break;
            case "ForeverAnchorChallenge":
                _challenge = new ForeverAnchorChallenge(x, score, current);
                break;
            case "ForeverMoonstoneChallenge":
                _challenge = new ForeverMoonstoneChallenge(x, score, current);
                break;
            case "ForeverRockChallenge":
                _challenge = new ForeverRockChallenge(x, score, current);
                break;
            case "StageAltitudeChallenge":
                _challenge = new StageAltitudeChallenge(x, score, current);
                break;
            case "StageAnchorChallenge":
                _challenge = new StageAnchorChallenge(x, score, current);
                break;
            case "StageMoonstoneChallenge":
                _challenge = new StageMoonstoneChallenge(x, score, current);
                break;
            case "CharacterChallenge":
                break;
            case "StageRockChallenge":
                _challenge = new StageRockChallenge(x, score);
                break;
        }
    }

    private void CreateChallenge()
    {
        ChallengeInfo challengeInfo = _challengeList[Random.Range(0, _challengeList.Count - 1)];
        int x = Random.Range(challengeInfo.minXValue, challengeInfo.maxXValue);
        int score = (int)(x * challengeInfo.multiplier * _challengeScoreMultiplierByLevel[ComputeLevel(TotalScore)]);

        switch (challengeInfo.name)
        {
            case "ForeverAltitudeChallenge":
                _challenge = new ForeverAltitudeChallenge(x, score);
                break;
            case "ForeverAnchorChallenge":
                _challenge = new ForeverAnchorChallenge(x, score);
                break;
            case "ForeverMoonstoneChallenge":
                _challenge = new ForeverMoonstoneChallenge(x, score);
                break;
            case "ForeverRockChallenge":
                _challenge = new ForeverRockChallenge(x, score);
                break;
            case "StageAltitudeChallenge":
                _challenge = new StageAltitudeChallenge(x, score);
                break;
            case "StageAnchorChallenge":
                _challenge = new StageAnchorChallenge(x, score);
                break;
            case "StageMoonstoneChallenge":
                _challenge = new StageMoonstoneChallenge(x, score);
                break;
            case "CharacterChallenge":
                break;
            case "StageRockChallenge":
                _challenge = new StageRockChallenge(x, score);
                break;
        }

        PlayerPrefs.SetString("ChallengeName", challengeInfo.name);
        PlayerPrefs.SetInt("ChallengeX", x);
        PlayerPrefs.SetInt("ChallengeCurrent", 0);
        PlayerPrefs.SetInt("ChallengeScore", score);
    }
}

//----------------------------------------------------------------------------------
//----------------------------------------------------------------------------------
//----------------------------------------------------------------------------------

[System.Serializable]
public class CharacterListElement
{
    public string charName;
    public GameObject prefab;
}

[System.Serializable]
public class AccelerationStepElement
{
    public int height;
    public float acceleration;
    public float scoreMultiplier;
}

[System.Serializable]
public class EnvironmentInfo
{
    public string name;
    public List<GameObject> uniqueChunks;
    public List<AccelerationStepElement> accelerationSteps;
    public bool spawnRocks;
    public float minRockSpawnTimer;
    public float maxRockSpawnTimer;
    public float rockSpawnOffset;
    public GameObject rockPrefab;
    public Sprite backgroundSprite;
    public GameObject ambiancePrefab;
    public Color crevasseColour;
    public Color wallColour;
    public Color wallShadowColour;
    public Material anchorMaterial;
    public Sprite plantSprite;
    public Sprite uiImage;
}

[System.Serializable]
public class ChallengeInfo
{
    public string name;
    public int minXValue;
    public int maxXValue;
    public float multiplier;
}