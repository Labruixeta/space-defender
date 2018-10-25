using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemeradorDisparControler : MonoBehaviour 
{
	public GameObject dispar_Prefab;
	public float dispar_Generator_Timer=0.5f;
	public Vector3 dispar_Posicio;
	private AudioSource soDispar;

	public void Start()
	{
		soDispar = GetComponent<AudioSource> ();
	}

	void CreateDispar1()
	{
		dispar_Posicio = transform.position;
		dispar_Posicio.y += 0.3f;
		Instantiate(dispar_Prefab, dispar_Posicio, Quaternion.identity);
		soDispar.Play ();
	}
	void CreateDispar2()
	{
		dispar_Posicio = transform.position;
		dispar_Posicio.x += 0.5f;
		Instantiate(dispar_Prefab, dispar_Posicio, Quaternion.identity);
		dispar_Posicio.x -= 1f;
		Instantiate(dispar_Prefab, dispar_Posicio, Quaternion.identity);
	}
	void CreateDispar3()
	{
		dispar_Posicio = transform.position;
		dispar_Posicio.x += 0.5f;
		Instantiate(dispar_Prefab, dispar_Posicio, Quaternion.identity);
		dispar_Posicio.x -= 1f;
		Instantiate(dispar_Prefab, dispar_Posicio, Quaternion.identity);
		dispar_Posicio.x += 0.5f;
		dispar_Posicio.y += 0.3f;
		Instantiate(dispar_Prefab, dispar_Posicio, Quaternion.identity);
	}



	public void StartDisparGenerator1()
	{
		InvokeRepeating("CreateDispar1", 0f, dispar_Generator_Timer);
	}
	public void StartDisparGenerator2()
	{
		InvokeRepeating("CreateDispar2", 0f, dispar_Generator_Timer);
	}
	public void StartDisparGenerator3()
	{
		InvokeRepeating("CreateDispar3", 0f, dispar_Generator_Timer);
	}

	public void CancelDisparGenerator()
	{
		CancelInvoke("CreateDispar1");
		CancelInvoke("CreateDispar2");
		CancelInvoke("CreateDispar3");
	}
}
