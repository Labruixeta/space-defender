using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemic3Controler : MonoBehaviour 
{
	public enum EstatEnemic3 { Inicial, Parat, Atacant, Final, Mort};
	public float enemic3_VELO=1f;
	public Rigidbody2D enemic3_RB2D;
	public PolygonCollider2D enemic3_PC2D;
	public Animator enemic3_ANIM;
	public int impactes = 0;
	public Vector3 posicio;
	public EstatEnemic3 estatEnemic3= EstatEnemic3.Inicial ;

	void Start () 
	{
		GameObject.Find ("ObjecteGeneradorDisparEnemic3").SendMessage ("StartDisparGenerator1");
		enemic3_RB2D = GetComponent<Rigidbody2D> ();
		enemic3_PC2D = GetComponent<PolygonCollider2D> ();
		enemic3_ANIM = GetComponent<Animator> ();
		
// -----------------------------------------------------------------------------------------------
//	INICI MOVIMENT
// -----------------------------------------------------------------------------------------------
		enemic3_RB2D.velocity = Vector2.down * enemic3_VELO;

	}
// -----------------------------------------------------------------------------------------------
//	COMPORTAMENT GENERAL
// -----------------------------------------------------------------------------------------------
	void Update () 
	{
		if (estatEnemic3==EstatEnemic3.Inicial)
		{
			if (enemic3_RB2D.position.y <= 3.2f)
			{
				enemic3_RB2D.velocity = Vector2.zero;
				estatEnemic3 = EstatEnemic3.Parat;
			}
		}
		if (estatEnemic3==EstatEnemic3.Parat)
		{
			//	INICI DISPAR?
			estatEnemic3=EstatEnemic3.Atacant;
			enemic3_RB2D.velocity = Vector2.right * enemic3_VELO;
		}
		if (estatEnemic3==EstatEnemic3.Atacant)
		{
			if (enemic3_RB2D.position.x >= 1.7f)
			{
				enemic3_RB2D.velocity = Vector2.left*enemic3_VELO;
			}
			if (enemic3_RB2D.position.x <= -1.7f)
			{
				enemic3_RB2D.velocity = Vector2.right*enemic3_VELO;
			}

		}


	}

// -----------------------------------------------------------------------------------------------
//	COL·LISIÖ AMD DISPAR O OBJECTE DESTRUCTOR
// -----------------------------------------------------------------------------------------------
	void OnTriggerEnter2D (Collider2D other)
	{
		GameObject main = GameObject.FindGameObjectWithTag ("Main");
		if (other.gameObject.tag == "DestructorEnemics") 
		{
			Destroy (gameObject);
		}
		else if (other.gameObject.tag == "PlayerDispar") 
		{
			// -----------------------------------------------------------------------------------
			//	IMPACTES I SUMA PUNTS
			// -----------------------------------------------------------------------------------
				impactes++;
				if (impactes==10)
				{
					main.GetComponent<GameControler> ().SumaPunts ();
					main.GetComponent<GameControler> ().SumaPunts ();
					main.GetComponent<GameControler> ().SumaPunts ();
				main.GetComponent<GameControler> ().CreaBonus (gameObject.transform.position);

					enemic3_PC2D.enabled = false;
				Destroy (gameObject);
					//enemic3_ANIM.Play ("Enemic2_boom");
				}
			}	
	}
// -----------------------------------------------------------------------------------------------
//	FUNCIO DESTRUCTORA REMOTA
// -----------------------------------------------------------------------------------------------

	public void EnemicDestructor ()
	{
		Destroy (gameObject);
	}
}
