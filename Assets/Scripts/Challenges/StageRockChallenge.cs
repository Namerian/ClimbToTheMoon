using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageRockChallenge : Challenge
{
    public int X { get; private set; }
    public int Current { get; private set; }
    public int Score { get; private set; }

    public string Name { get { return "StageRockChallenge"; } }
    public bool Completed { get { return Current >= X; } }
    public string Description { get { return "Survive being hit by a rock! " + X + " times! (in one go) - " + Current + "/" + X; } }

    private bool _hitByRock = false;

    public StageRockChallenge(int x, int score, int current = 0)
    {
        X = x;
        Current = current;
        Score = score;

        EventManager.Instance.OnRockCollisionEvent += OnRockCollisionEvent;
        EventManager.Instance.OnAnchorGrabbedEvent += OnAnchorGrabbedEvent;
        EventManager.Instance.OnStageStartedEvent += OnStageStartedEvent;
    }

    private void OnStageStartedEvent()
    {
        if (!Completed)
        {
            _hitByRock = false;
            Current = 0;
        }
    }

    private void OnAnchorGrabbedEvent()
    {
        if (!Completed && _hitByRock)
        {
            Current++;
        }
    }

    private void OnRockCollisionEvent()
    {
        if (!Completed)
        {
            _hitByRock = true;
        }
    }
}
