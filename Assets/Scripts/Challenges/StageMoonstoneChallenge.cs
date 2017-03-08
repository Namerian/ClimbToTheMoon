using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageMoonstoneChallenge : Challenge
{
    public int X { get; private set; }
    public int Current { get; private set; }
    public int Score { get; private set; }
    public int Lifetime { get; private set; }

    public string Name { get { return "StageMoonstoneChallenge"; } }
    public bool Completed { get { return Current >= X; } }
    public string Description { get { return "Collect " + X + " Moonstones! (in one go) - " + Current + "/" + X; } }

    public StageMoonstoneChallenge(int x, int score, int current = 0)
    {
        X = x;
        Current = current;
        Score = score;

        EventManager.Instance.OnStageStartedEvent += OnStageStartedEvent;
        EventManager.Instance.OnMoonstoneCollectedEvent += OnMoonstoneCollectedEvent;
        EventManager.Instance.OnStageEndedEvent += OnStageEndedEvent;
    }

    private void OnStageEndedEvent(int altitude, string character)
    {
        if (!Completed)
        {
            Lifetime++;
        }
    }

    private void OnMoonstoneCollectedEvent()
    {
        if (!Completed)
        {
            Current++;
        }
    }

    private void OnStageStartedEvent()
    {
        if (!Completed)
        {
            Current = 0;
        }
    }
}
