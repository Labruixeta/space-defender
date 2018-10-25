using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlDisparEnemic : MonoBehaviour
{
	public float disparEnemic_VELO=5f;
	public Rigidbody2D disparEnemic_RB2D;
	public PolygonCollider2D disparEnemic_PC2D;
	public Vector3 disparPosIni;

	void Start () 
	{
		disparEnemic_RB2D = GetComponent<Rigidbody2D> ();
		disparEnemic_PC2D = GetComponent<PolygonCollider2D> ();
		//GameObject.FindGameObjectWithTag ("Player").GetComponent<Rigidbody2D> ().transform.position;
		disparPosIni =GameObject.FindGameObjectWithTag ("Player").GetComponent<Rigidbody2D> ().transform.position;// new Vector3(0f,0f,0f);
		//disparEnemic_RB2D.velocity= new Vector2(1f,-5f);
	
		//disparEnemic_RB2D.velocity =  Vector2.down* disparEnemic_VELO;
	}

	void Update () 
	{

		disparEnemic_RB2D.transform.position = Vector3.MoveTowards(transform.position, disparPosIni, disparEnemic_VELO * Time.deltaTime);
		if (disparEnemic_RB2D.transform.position==disparPosIni)
		{
			disparPosIni.y =- 10f;
			//Destroy (gameObject);
		}
	}
	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.gameObject.tag == "DestructorDispar") 
		{
			Destroy (gameObject);
		}
		else if (other.gameObject.tag == "Player") 
		{
			Destroy (gameObject);
		}

	}
	public void Enemic3Dispara()
	{
		
	}
}
