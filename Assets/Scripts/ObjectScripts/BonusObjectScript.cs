using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusObjectScript : MonoBehaviour
{
    [SerializeField]
    private float _bonusScore;

    public float BonusScore { get { return _bonusScore; } }
}
