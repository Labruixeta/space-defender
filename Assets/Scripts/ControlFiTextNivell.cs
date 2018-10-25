using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlFiTextNivell : MonoBehaviour 
{
	public GameObject canvasPrincipal; 
	void Start () 
	{

	}
	
	void Update () 
	{
		
	}
	void GameReady()
	{
		canvasPrincipal.GetComponent<GameControler> ().gameState = GameState.PrePlaying;
	}
}
