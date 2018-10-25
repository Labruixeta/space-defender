using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum GameState { Idle, Waiting, PrePlaying, playing, ended, end, Mort }

public class GameControler : MonoBehaviour 
{
	public RawImage fons;
	public RawImage planeta;
	public RawImage fons_NIVELL1;
	public RawImage fons_NIVELL2;

	public GameObject canvas_intro_LV1;
	public GameObject canvas_intro;
	public GameObject canvas_fi;
	public GameObject canvas_consola;
	public GameObject player;
	public GameObject enemic1_generador;
	public GameObject enemic2_generador;
	public GameObject dispar_generador;
	public GameObject enemic_Prefab;
	public GameObject bonus_Prefab;
	public GameObject intro;
	public GameObject intro2;

	public GameState gameState = GameState.Idle;

	public float contador;
	public float parallaxSpeed = 0.02f;

	public string text_nivell;

	public int nivell = 1;
	public int punts = 0;
	public int maxPunts=0;

	public Text nivell_text;
	public Text text_punts;
	public Text text_maxpunts;
	public Text text_de_nivell;

	public Vector3 playerPosIni;

	private AudioSource musicPlayer;

	void Start () 
	{	
		planeta.enabled=false;
		fons_NIVELL1.enabled = false;
		fons_NIVELL2.enabled = false;
		playerPosIni = player.transform.position;
		player.SetActive (false);
		canvas_consola.SetActive (false);
		canvas_intro_LV1.SetActive (false);
		canvas_fi.SetActive (false);
		musicPlayer = GetComponent<AudioSource> ();
	}

	void Update () 
	{
		float finalSpeed = parallaxSpeed * Time.deltaTime;
		bool usserAction = Input.GetMouseButtonDown (0);
		// Seleccio de l'estat del joc
		// ----------------------------------------------------------------------------
		// IDLE
		// ----------------------------------------------------------------------------
		if (gameState == GameState.Idle)
		{	
			musicPlayer.Stop ();
			if (usserAction) 
			{
				usserAction = false;	
				EncenInici ();
			} 
			else {
				fons.uvRect = new Rect (0f, fons.uvRect.y + finalSpeed, 1f, 1f); 
				intro.transform.Rotate (new Vector3(0f,0f,0.05f));
				intro2.transform.Rotate (new Vector3(0f,0f,-0.2f));
			}
		}
		// ----------------------------------------------------------------------------
		// WAITING
		// ----------------------------------------------------------------------------
		else if (gameState == GameState.Waiting)
		{
			fons.uvRect = new Rect (0f, fons.uvRect.y + finalSpeed, 1f, 1f); 
		}
		// ----------------------------------------------------------------------------
		// PRE PLAYING
		// ----------------------------------------------------------------------------
		else if (gameState == GameState.PrePlaying) 
		{
			musicPlayer.Play ();
			planeta.enabled = true;
			fons_NIVELL1.enabled = false;
			fons_NIVELL2.enabled = false;
			canvas_intro_LV1.SetActive(false);
			canvas_consola.SetActive (true);
			player.transform.position = playerPosIni;
			player.SetActive (true);
			dispar_generador.SendMessage ("StartDisparGenerator1");
			gameState = GameState.playing;
			switch (nivell) 
			{
				case 1:
				Invoke("CreaEnemic" ,5F);
				enemic1_generador.SendMessage ("StartGenerator");
				break;
				case 2:
				Invoke("CreaEnemic" ,5F);
				Invoke("CreaEnemic" ,10F);
				enemic1_generador.SendMessage ("StartGenerator");
				enemic2_generador.SendMessage ("StartGenerator2");
				break;
			}
		}
		// ----------------------------------------------------------------------------
		// PLAYING
		// ----------------------------------------------------------------------------
		else if (gameState == GameState.playing) 
		{
			switch (nivell) 
			{
				case 1:
					jugant ();
				break;

				case 2:
					jugant ();
				break;

			}

		}
		// ----------------------------------------------------------------------------
		// ENDED
		// ----------------------------------------------------------------------------
		else if (gameState == GameState.ended) 
		{
			fons.uvRect = new Rect (0f, fons.uvRect.y + contador, 1f, 1f);
			planeta.uvRect = new Rect (0f, planeta.uvRect.y + contador / 4, 1f, 1f);
			player.GetComponent<Rigidbody2D> ().velocity = new Vector3 (0f,3f,0f);
			contador += 0.001f;
		
		}
		// ----------------------------------------------------------------------------
		// END
		// ----------------------------------------------------------------------------
		else if (gameState == GameState.end) 
		{
			nivell++;
			canvas_fi.SetActive (false);

			planeta.uvRect = new Rect (0f, 0f, 1f, 1f);
			planeta.enabled = false;
			contador = finalSpeed;
			parallaxSpeed = 0.02f;
			player.GetComponent<Rigidbody2D> ().velocity = new Vector3 (0f,0f,0f);
			EncenInici ();
		}
		// ----------------------------------------------------------------------------
		// MORT
		// ----------------------------------------------------------------------------
		else if (gameState == GameState.Mort) 
		{
			//canvas_fi.SetActive (false);
			ParaGeneradorsEnemics ();
			planeta.uvRect = new Rect (0f, 0f, 1f, 1f);
			planeta.enabled = false;
			contador = finalSpeed;
			parallaxSpeed = 0.02f;
			nivell = 1;
			canvas_consola.SetActive (false);
			player.SetActive (false);
			canvas_intro.SetActive (true);
			intro.SetActive (true);
			if (punts > maxPunts) 
			{
				maxPunts = punts;
			}
			punts = 0;
			text_maxpunts.text = "max points : " + maxPunts;
			text_punts.text = "" + punts;
			player.GetComponent<PolygonCollider2D> ().enabled = true;
			gameState = GameState.Idle;
		}
	}

	void EncenInici()
	{
		
		switch (nivell) 
		{
		case 1:
			text_nivell = "- MART -";
			fons_NIVELL1.enabled = true;
			planeta.texture = Resources.Load<Texture> ("LV1_FonsMart");
			break;	
			case 2:
			text_nivell = "- JUPITER -";
			fons_NIVELL2.enabled = true;
			planeta.texture = Resources.Load<Texture> ("LV2_FonsJupiter");
			break;
			case 3:
			text_nivell = "- SATURN -";
//			planeta.texture = Resources.Load<Texture> ("LV3_FonsSaturn");
			break;
		}
		nivell_text.text = "NIVELL " + nivell + "       " + text_nivell;
		intro.SetActive (false);
		canvas_intro.SetActive (false);
		canvas_intro_LV1.SetActive(true);
		text_de_nivell.text = "" + nivell;
		gameState = GameState.Waiting;
	}

	void jugant()
	{
		float finalSpeed2 = parallaxSpeed * Time.deltaTime;
		// Efecte de fons
		if (planeta.uvRect.y < 0.555f) 
		{
			fons.uvRect = new Rect (0f, fons.uvRect.y + finalSpeed2, 1f, 1f);
			planeta.uvRect = new Rect (0f, planeta.uvRect.y + finalSpeed2 / 4, 1f, 1f);
		} 
		// HAS GUANYAT !
		else 
		{
			ParaGeneradorsEnemics ();
			dispar_generador.SendMessage ("CancelDisparGenerator");
			canvas_fi.SetActive (true);
			contador = finalSpeed2;
			gameState = GameState.ended;
		}
	}

	void ParaGeneradorsEnemics()
	{
		enemic1_generador.SendMessage ("CancelGenerator");
		enemic2_generador.SendMessage ("CancelGenerator2");
		//Elimina tots els enemics restants
		object[] allEnemics = GameObject.FindGameObjectsWithTag("Enemic");
		foreach (GameObject enemic in allEnemics) 
		{
			Destroy (enemic);
		}
	}

	public void SumaPunts()
	{
		punts++;
		text_punts.text = "" + punts;
	}

	void CreaEnemic()
	{
		Instantiate (enemic_Prefab, new Vector3 (0f, 10f, 0f), Quaternion.identity);
	}
	public void CreaBonus(Vector3 posicio)
	{
		Instantiate (bonus_Prefab, posicio, Quaternion.identity);
	}
}
