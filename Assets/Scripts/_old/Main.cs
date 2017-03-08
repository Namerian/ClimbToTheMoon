using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*public class Main : MonoBehaviour
{
	Player player = new Player();

	public void Start()
	{
		// Setup your Amplitude id
		AmplitudeHelper.AppId = "46acae4acfda355a0ed8a9c46d81007a";

		// Connect a callback that will be used to fill some meta data every time a log Event is sent
		// This is very useful to track some properties that are not related to a specific event, and
		// be able analyze their progression during the whole session
		AmplitudeHelper.Instance.FillCustomProperties += FillTrackingProperties;

		// Begin tracking
		AmplitudeHelper.Instance.StartSession();

		// ...

		// Start some gameplay
		player.EnterMainMenu();

		GameObject.Find("Money").GetComponent<Text>().text = player.Money.ToString() + " coins";

		StartCoroutine(WaitAndLaunchLevel());
	}

	void OnDestroy()
	{
		// End tracking
		AmplitudeHelper.Instance.EndSession();
	}

	void FillTrackingProperties(Dictionary<string, object> properties)
	{
		properties["xp"] = player.XP;
		properties["money"] = player.Money;
	}

	IEnumerator WaitAndLaunchLevel()
	{
		// Launch a level in 5s
		yield return new WaitForSeconds(5);

		player.StartLevel("Level 5", 3);
	}

	public void OnButtonClicked()
	{
		player.Money += 100;

		GameObject.Find("Money").GetComponent<Text>().text = player.Money.ToString() + " coins";

		AmplitudeHelper.Instance.LogEvent("Button has been clicked");
	}
}

// Example of game class
class Player
{
	public int XP;
	public int Money;
	public float Energy;

	public void EnterMainMenu()
	{
		AmplitudeHelper.Instance.LogEvent("Enter MainMenu");

		// Open MainMenu UI
		// ...
	}

	public void StartLevel(string levelName, int difficulty)
	{
		var customProperties = new Dictionary<string, object>()
		{
			{ "Level", levelName },
			{ "Difficulty", difficulty },
		};
		AmplitudeHelper.Instance.LogEvent("StartGame", customProperties);

		// Do something to start the level
		// ...
	}
}*/
