using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneradorEnemic2Controler : MonoBehaviour {
	public GameObject enemic2_Prefab;
	public float enemic2_Generator_Timer=4.25f;
	public Vector3 enemic2_Posicio;
	//	public float enemic1_Random;
	public void Start()
	{
	}

	void CreateEnemy2()
	{
		enemic2_Posicio = transform.position ;
		enemic2_Posicio.x = enemic2_Posicio.x + 2f * Random.Range(-1f,1f);
		Instantiate(enemic2_Prefab, enemic2_Posicio, Quaternion.identity);
	}

	public void StartGenerator2()
	{
		InvokeRepeating("CreateEnemy2", 0f, enemic2_Generator_Timer);
	}

	public void CancelGenerator2()
	{
		CancelInvoke("CreateEnemy2");
	}
}
