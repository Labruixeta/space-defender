using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControl : MonoBehaviour 
{
	public GameObject game;
	//public Text consola;
	//public GameObject enemyControler;
	public GameObject disparControler;
	private Animator animador;
	private Rigidbody2D playerRB;
	public float playerVelocity = 5f;
	public Vector3 PosIni;
	public Vector3 PosFin;
	public bool movent=false;
	private AudioSource soPlayerDead;

	public bool clicInici=false;


	void Start () {
		soPlayerDead = GetComponent<AudioSource>();
		animador = GetComponent<Animator>();
		playerRB= GetComponent<Rigidbody2D>();
	}

	void Update () 
	{
		bool gamePlaying = game.GetComponent<GameControler>().gameState == GameState.playing;
		bool usserAction = (Input.GetKeyDown("up") || Input.GetMouseButtonDown(0));

		//-----------------------------------------------------------------------------------
		//						MOVENT AL CLIC
		//-----------------------------------------------------------------------------------
		if (gamePlaying && movent && (playerRB.transform.position != PosIni)) {
			playerRB.transform.position = Vector3.MoveTowards(transform.position, PosIni, playerVelocity * Time.deltaTime);
			if (playerRB.transform.position==PosIni)
			{
				movent = false;
			}
		}
		if (gamePlaying && usserAction)
		{
			/*if (clicInici == false)
			{
				clicInici = true;
			}
			else
			{*/
				PosIni = Camera.main.ScreenToWorldPoint(Input.mousePosition);
				PosIni.z = 0f;
				movent = true;

		}

	}

	public void UpdateState (string state = null){
		if (state !=null){
			animador.Play(state);
		}
	}

	// ------------------------------------------------------------------------------------------
	// 									COLISIO
	// ------------------------------------------------------------------------------------------
	void OnTriggerEnter2D(Collider2D other)
	{
		// ENEMIC
		if (other.gameObject.tag == "Enemic")
		{
			UpdateState("PlayerBoom");
			soPlayerDead.Play();
			gameObject.GetComponent<PolygonCollider2D>().enabled = false;
			disparControler.SendMessage("CancelDisparGenerator");
		}
		else if (other.gameObject.tag == "EnemicDispar")
		{
			UpdateState("PlayerBoom");
			soPlayerDead.Play();
			gameObject.GetComponent<PolygonCollider2D>().enabled = false;
			disparControler.SendMessage("CancelDisparGenerator");
		}
		else if (other.gameObject.tag == "BonusX3")
		{
			//gameObject.GetComponent<PolygonCollider2D>().enabled = false;
			disparControler.SendMessage("CancelDisparGenerator");
			disparControler.SendMessage("StartDisparGenerator3");
		}

	}

	void AcabaPerMort()
	{
		game.GetComponent<GameControler>().gameState = GameState.Mort;

	}
}
