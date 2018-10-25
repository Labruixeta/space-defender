using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneradorDisparEnemic3 : MonoBehaviour {

	public GameObject disparEnemic3_Prefab;

	public float disparEnemic3GeneratorTimer=0.5f;
	public Vector3 disparEnemic3_Posicio;

	public void Start()
	{
	}

	void CreateDisparEnemic3()
	{
		disparEnemic3_Posicio = transform.position;
		Instantiate(disparEnemic3_Prefab, disparEnemic3_Posicio, Quaternion.identity);
	}

	public void StartDisparGenerator1()
	{
		InvokeRepeating("CreateDisparEnemic3", 5f, disparEnemic3GeneratorTimer);
	}

	public void CancelDisparGenerator()
	{
		CancelInvoke("CreateDisparEnemic3");
	}

}
