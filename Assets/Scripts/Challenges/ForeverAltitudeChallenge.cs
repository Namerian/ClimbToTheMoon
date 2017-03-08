using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForeverAltitudeChallenge : Challenge
{
    public int X { get; private set; }
    public int Current { get; private set; }
    public int Score { get; private set; }

    public string Name { get { return "StageAnchorChallenge"; } }
    public bool Completed { get { return Current >= X; } }
    public string Description { get { return ""; } }

    public ForeverAltitudeChallenge(int x, int score, int current = 0)
    {
        X = x;
        Current = current;
        Score = score;

        EventManager.Instance.OnStageEndedEvent += OnStageEndedEvent;
    }

    private void OnStageEndedEvent(int altitude, string character)
    {
        if (!Completed)
        {
            Current += altitude;
        }
    }
}
