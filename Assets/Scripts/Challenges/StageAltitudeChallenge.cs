using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageAltitudeChallenge : Challenge
{
    public int X { get; private set; }
    public int Current { get; private set; }
    public int Score { get; private set; }

    public string Name { get { return "StageAltitudeChallenge"; } }
    public bool Completed { get { return Current >= X; } }
    public string Description { get { return ""; } }

    public StageAltitudeChallenge(int x, int score, int current = 0)
    {
        X = x;
        Current = current;
        Score = score;

        EventManager.Instance.OnStageEndedEvent += OnStageEndedEvent;
    }

    private void OnStageEndedEvent(int altitude, string character)
    {
        if (altitude > Current && !Completed)
        {
            Current = altitude;
        }
    }
}
