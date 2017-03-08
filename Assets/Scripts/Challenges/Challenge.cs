using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Challenge
{
    int X { get; }
    int Current { get; }
    int Score { get; }
    int Lifetime { get; }

    string Name { get; }
    bool Completed { get; }
    string Description { get; }
}
