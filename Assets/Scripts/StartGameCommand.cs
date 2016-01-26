using UnityEngine;
using System.Collections;

public class StartGameCommand : MonoBehaviour 
{
	public MeshRenderer scrittaIniziale;
	
	private bool isStarted = false;

	void Awake()
	{
		
	}
	
	void Update () 
	{
		
		// If it's the first time and any button has been pressed, start the game
		if (Input.anyKey && !isStarted)
		{
			// Coroutine makes the player wait a bit before actually starting the ride
			Time.timeScale = 1;
			scrittaIniziale.enabled = false;
			isStarted = true;
		}
	}
	
}
