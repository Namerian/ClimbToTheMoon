// https://github.com/amplitude/unity-plugin

using System;
using System.Collections.Generic;
using UnityEngine;

public class AmplitudeHelper
{
    //===============================================================================
    //
    //===============================================================================

    private static AmplitudeHelper instance;
    public static AmplitudeHelper Instance
    {
        get
        {
            if (instance == null)
                instance = new AmplitudeHelper();
            return instance;
        }
    }

    //===============================================================================
    //
    //===============================================================================

    public static string AppId;

	public delegate void FillPropertiesDel(Dictionary<string, object> properties);
	public event FillPropertiesDel FillCustomProperties;

	private Amplitude amplitude;
	private Dictionary<string, object> UserProperties = new Dictionary<string, object>();

    //===============================================================================
    //
    //===============================================================================

    public AmplitudeHelper()
	{
		amplitude = Amplitude.Instance;
		amplitude.logging = true;

		if (string.IsNullOrEmpty(AppId))
		{
			Debug.LogError("Cannot instantiate Amplitude without proper AppId");
			return;
		}

		amplitude.trackSessionEvents(true);
        amplitude.logging = true;
		amplitude.init(AppId);

		// We chose to use the deviceId as unique userId
		if (!String.IsNullOrEmpty(SystemInfo.deviceUniqueIdentifier))
			amplitude.setUserId(SystemInfo.deviceUniqueIdentifier);
	}

	public void Reset()
	{
		foreach (var d in FillCustomProperties.GetInvocationList())
			FillCustomProperties -= d as FillPropertiesDel;
	}

    //===============================================================================
    //
    //===============================================================================

    public void StartSession()
	{
		amplitude.startSession();
	}

	public void EndSession()
	{
		amplitude.endSession();
	}

    //===============================================================================
    //
    //===============================================================================

    public void LogEvent(string eventToReport)
	{
		UpdateUserProperties();
		amplitude.logEvent(eventToReport);
	}

	public void LogEvent(string eventToReport, IDictionary<string, object> properties)
	{
		UpdateUserProperties();
		amplitude.logEvent(eventToReport, properties);
	}

    //===============================================================================
    //
    //===============================================================================

    void UpdateUserProperties()
	{
		UserProperties.Clear();

		try
		{
			FillCustomProperties(UserProperties);
		}
		catch (Exception e)
		{
			Debug.LogException(e);
		}

		amplitude.setUserProperties(UserProperties);
	}
}

