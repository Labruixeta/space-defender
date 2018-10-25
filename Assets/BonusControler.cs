using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusControler : MonoBehaviour {
	public CircleCollider2D bonusColider;
	public Rigidbody2D bonusRigid2D;

	void Start () 
	{
		bonusColider = GetComponent<CircleCollider2D> ();
		bonusRigid2D = GetComponent<Rigidbody2D> ();
		bonusRigid2D.velocity=Vector2.down* ( 15f * Time.deltaTime);
	}

	void Update () {
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.gameObject.tag == "DestructorEnemics") 
		{
			Destroy (gameObject);
		}
		else if (other.gameObject.tag == "Player") 
		{
			Destroy (gameObject);
		}
	}

	public void EnemicDestructor ()
	{
		Destroy (gameObject);
	}
}
