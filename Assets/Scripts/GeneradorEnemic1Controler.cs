using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneradorEnemic1Controler : MonoBehaviour 
{
	public GameObject enemic1_Prefab;
	public float enemic1_Generator_Timer=2.75f;
	public Vector3 enemic1_Posicio;
//	public float enemic1_Random;
	public void Start()
	{
	}

	void CreateEnemy()
	{
		enemic1_Posicio = transform.position ;
		enemic1_Posicio.x = enemic1_Posicio.x + 2f * Random.Range(-1f,1f);
		Instantiate(enemic1_Prefab, enemic1_Posicio, Quaternion.identity);
	}

	public void StartGenerator()
	{
		InvokeRepeating("CreateEnemy", 0f, enemic1_Generator_Timer);
	}

	public void CancelGenerator()
	{
		CancelInvoke("CreateEnemy");
	}
}
