using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.UI;

public class Enemic1Contoler : MonoBehaviour 
{
	
	
	public float enemic1_VELO=5f;
	public Rigidbody2D enemic1_RB2D;
	public PolygonCollider2D enemic1_PC2D;
	public Animator enemic1_ANIM;
	public int impactes = 0;
	private AudioSource soEnemic1;

	void Start () 
	{
		enemic1_RB2D = GetComponent<Rigidbody2D> ();
		enemic1_PC2D = GetComponent<PolygonCollider2D> ();
		enemic1_ANIM = GetComponent<Animator> ();
		soEnemic1 = GetComponent<AudioSource> ();
		enemic1_RB2D.velocity = Vector2.down * enemic1_VELO;
	}
	
	void Update () 
	{
		
	}
	void OnTriggerEnter2D (Collider2D other)
	{
		GameObject main = GameObject.FindGameObjectWithTag ("Main");
		if (other.gameObject.tag == "DestructorEnemics") 
		{
			Destroy (gameObject);
		}
		else if (other.gameObject.tag == "PlayerDispar") 
		{
			if (gameObject.name.Contains ("Enemic_nou")) 
			{
				main.GetComponent<GameControler> ().SumaPunts ();
				enemic1_PC2D.enabled = false;
				enemic1_ANIM.Play ("Enemic1_boom");
				soEnemic1.Play ();
			} 
			else if (gameObject.name.Contains ("Enemic2")) 
			{
				impactes++;
				if (impactes==5)
				{
					main.GetComponent<GameControler> ().SumaPunts ();
					main.GetComponent<GameControler> ().SumaPunts ();
					main.GetComponent<GameControler> ().SumaPunts ();
					enemic1_PC2D.enabled = false;
					enemic1_ANIM.Play ("Enemic2_boom");
				}
			}	
		
		}

	}
	public void EnemicDestructor ()
	{
		Destroy (gameObject);
	}
}