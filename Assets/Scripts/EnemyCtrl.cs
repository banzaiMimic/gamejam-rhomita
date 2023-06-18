using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyCtrl : MonoBehaviour
{
    [SerializeField]
    private GameObject targetPosition; //Objetivo para alcanzar
    [SerializeField]
    private Animator animatorEnemy;

	private void Start()
	{
		targetPosition = GameObject.FindGameObjectWithTag("TargetEnemy");
	}

	private void Update()
	{
		GetComponent<NavMeshAgent>().destination = targetPosition.transform.position;
		
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject == targetPosition)
		{
			//daño
			animatorEnemy.SetBool("Contacto", true);
		}
	}
}
