using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisparContoler : MonoBehaviour 
{
	public float dispar_VELO=10f;
	public Rigidbody2D dispar_RB2D;
	public PolygonCollider2D dispar_PC2D;
	public Animator dispar_ANIM;

	void Start () 
	{
		dispar_RB2D = GetComponent<Rigidbody2D> ();
		dispar_PC2D = GetComponent<PolygonCollider2D> ();
		dispar_ANIM = GetComponent<Animator> ();
		dispar_RB2D.velocity = Vector2.up * dispar_VELO;
	}

	void Update () 
	{

	}
	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.gameObject.tag == "DestructorDispar") 
		{
			Destroy (gameObject);
		}
		else if (other.gameObject.tag == "Enemic") 
		{
			Destroy (gameObject);
		}

	}
}
