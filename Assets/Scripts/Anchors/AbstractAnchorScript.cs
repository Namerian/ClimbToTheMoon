using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractAnchorScript : MonoBehaviour
{
    public bool IsInUse { get; set; }
    public bool usedOnce { get; set; }

    public abstract void Respawn();
}
