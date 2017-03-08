using UnityEngine;
using System.Collections;

public delegate void OnStageStartedDelegate ();
public delegate void OnStageEndedDelegate (int altitude, string character);
public delegate void OnAnchorGrabbedDelegate ();
public delegate void OnMoonstoneCollectedDelegate ();
public delegate void OnRockCollisionDelegate();

public class EventManager
{
	private static EventManager _instance;

	public static EventManager Instance {
		get {
			if (_instance == null) {
				_instance = new EventManager ();
			}

			return _instance;
		}
	}

	//==================================================================================
	//
	//==================================================================================

	public event OnStageStartedDelegate OnStageStartedEvent;
	public event OnStageEndedDelegate OnStageEndedEvent;
	public event OnAnchorGrabbedDelegate OnAnchorGrabbedEvent;
	public event OnMoonstoneCollectedDelegate OnMoonstoneCollectedEvent;
    public event OnRockCollisionDelegate OnRockCollisionEvent;

	//==================================================================================
	//
	//==================================================================================

	public void SendOnStageStartedEvent ()
	{
		OnStageStartedDelegate tmp = OnStageStartedEvent;

		if (tmp != null) {
			this.OnStageStartedEvent ();
		}
	}

    public void SendOnStageEndedEvent(int altitude, string character)
	{
		OnStageEndedDelegate tmp = OnStageEndedEvent;

		if (tmp != null) {
			this.OnStageEndedEvent (altitude, character);
		}
	}

	public void SendOnAnchorGrabbedEvent ()
	{
		OnAnchorGrabbedDelegate tmp = OnAnchorGrabbedEvent;

		if (tmp != null) {
			this.OnAnchorGrabbedEvent ();
		}
	}

	public void SendOnMoonstoneCollectedEvent ()
	{
		OnMoonstoneCollectedDelegate tmp = OnMoonstoneCollectedEvent;

		if (tmp != null) {
			this.OnMoonstoneCollectedEvent ();
		}
	}

    public void SendOnRockCollisionEvent()
    {
        OnRockCollisionDelegate tmp = OnRockCollisionEvent;

        if(tmp != null)
        {
            this.OnRockCollisionEvent();
        }
    }
}
