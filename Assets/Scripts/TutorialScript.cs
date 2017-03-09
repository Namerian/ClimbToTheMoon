using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialScript : MonoBehaviour
{
    void Awake()
    {
        if (GameManagerScript.Instance.EnvironmentName != "Ocean")
        {
            this.gameObject.SetActive(false);
        }

        EventManager.Instance.OnAnchorGrabbedEvent += OnAnchorGrabbedEvent;
    }

    void OnDestroy()
    {
        EventManager.Instance.OnAnchorGrabbedEvent -= OnAnchorGrabbedEvent;
    }

    private void OnAnchorGrabbedEvent()
    {
        EventManager.Instance.OnAnchorGrabbedEvent -= OnAnchorGrabbedEvent;
        this.gameObject.SetActive(false);
    }
}
