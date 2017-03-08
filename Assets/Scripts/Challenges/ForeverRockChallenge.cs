using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForeverRockChallenge : Challenge
{
    public int X { get; private set; }
    public int Current { get; private set; }
    public int Score { get; private set; }

    public string Name { get { return "StageAltitudeChallenge"; } }
    public bool Completed { get { return Current >= X; } }
    public string Description { get { return ""; } }

    private bool _hitByRock=false;

    public ForeverRockChallenge(int x, int score, int current = 0)
    {
        X = x;
        Current = current;
        Score = score;

        EventManager.Instance.OnRockCollisionEvent += OnRockCollisionEvent;
        EventManager.Instance.OnAnchorGrabbedEvent += OnAnchorGrabbedEvent;
        EventManager.Instance.OnStageEndedEvent += OnStageEndedEvent;
    }

    private void OnStageEndedEvent(int altitude, string character)
    {
        if (!Completed)
        {
            _hitByRock = false;
        }
    }

    private void OnAnchorGrabbedEvent()
    {
        throw new System.NotImplementedException();
    }

    private void OnRockCollisionEvent()
    {
        throw new System.NotImplementedException();
    }
}
