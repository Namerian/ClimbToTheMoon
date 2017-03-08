using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterChallenge : Challenge
{
    public int X { get; private set; }
    public int Current { get; private set; }
    public int Score { get; private set; }
    public int Lifetime { get; private set; }

    public string Name { get { return "CharacterChallenge"; } }
    public bool Completed { get { return Current >= X; } }
    public string Description { get { return ""; } }

    private string _character;

    public CharacterChallenge(int x, string character, int score, int current = 0)
    {
        X = x;
        Current = current;
        Score = score;

        EventManager.Instance.OnStageEndedEvent += OnStageEndedEvent;
    }

    private void OnStageEndedEvent(int altitude, string character)
    {
        if (!Completed && character == _character && altitude > 0)
        {
            Current++;
        }
    }
}
