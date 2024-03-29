﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageAnchorChallenge : Challenge
{
    public int X { get; private set; }
    public int Current { get; private set; }
    public int Score { get; private set; }
    public int Lifetime { get; private set; }

    public string Name { get { return "StageAnchorChallenge"; } }
    public bool Completed { get { return Current >= X; } }
    public string Description { get { return "Grab " + X + " Anchors! (in one go) - " + Current + "/" + X; } }

    public StageAnchorChallenge(int x, int score, int current = 0)
    {
        X = x;
        Current = current;
        Score = score;

        EventManager.Instance.OnStageStartedEvent += OnStageStartedEvent;
        EventManager.Instance.OnAnchorGrabbedEvent += OnAnchorGrabbedEvent;
        EventManager.Instance.OnStageEndedEvent += OnStageEndedEvent;
    }

    private void OnStageEndedEvent(int altitude, string character)
    {
        if (!Completed)
        {
            Lifetime++;
        }
    }

    private void OnAnchorGrabbedEvent()
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
