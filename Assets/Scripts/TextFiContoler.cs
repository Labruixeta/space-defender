using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextFiContoler : MonoBehaviour {
	public GameObject canvasPrincipal2; 
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void GameReady2()
	{
		canvasPrincipal2.GetComponent<GameControler> ().gameState = GameState.end;
	}
}
