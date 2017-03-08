using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForeverAnchorChallenge : Challenge
{
    public int X { get; private set; }
    public int Current { get; private set; }
    public int Score { get; private set; }

    public string Name { get { return "ForeverAnchorChallenge"; } }
    public bool Completed { get { return Current >= X; } }
    public string Description { get { return "Grab " + X + " Anchors! (cumulated) - " + Current + "/" + X; } }

    public ForeverAnchorChallenge(int x, int score, int current = 0)
    {
        X = x;
        Current = current;
        Score = score;

        EventManager.Instance.OnAnchorGrabbedEvent += OnAnchorGrabbedEvent;
    }

    private void OnAnchorGrabbedEvent()
    {
        if (!Completed)
        {
            Current++;
        }
    }
}
