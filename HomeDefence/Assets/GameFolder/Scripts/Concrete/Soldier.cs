using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Soldier : MonoBehaviour, IDamagable
{
	public float pathEndThreshold = 0.1f;
	public float health = 100;
	public Animator animator;
	public bool isEnemy;

	private Camera cam;
	private NavMeshAgent agent;
	private Vector3 target;
	private bool onTouch = false;
	private float damageAmount = 100;
	private float sliderBar = 1;
	private bool isTriggered = false;

	private void Start()
	{
		agent = GetComponent<NavMeshAgent>();
		cam = Camera.main;
		if (!isEnemy)
			target = GetComponentInParent<SoldierPool>().target.position;
		else
			target = GetComponentInParent<EnemySoldierPool>().enemyTarget.position;
	}
	private void Update()
	{
		if (isEnemy)
			agent.SetDestination(target);
		else
		{
			if (Input.GetMouseButtonDown(0))
			{
				onTouch = true;
				Ray ray = cam.ScreenPointToRay(Input.mousePosition);
				RaycastHit hit;

				if (Physics.Raycast(ray, out hit))
				{
					agent.SetDestination(hit.point);
				}

			}

			if (!onTouch)
			{
				agent.SetDestination(target);
			}
			AtEndOfPath();
		}


	}

	bool AtEndOfPath()
	{

		if (agent.remainingDistance <= agent.stoppingDistance + pathEndThreshold)
		{
			// Arrived
			onTouch = false;
			return true;
		}
		return false;
	}
	private void OnTriggerEnter(Collider other)
	{
		if (!isTriggered)
		{
			IDamagable otherDamagable = other.GetComponent<IDamagable>();
			if (otherDamagable != null)
			{
				OnDamage();
			}
			isTriggered = true;
		}

	}
	public void OnDamage()
	{
		if (isEnemy)
		{
			UiController.Instance.ShowTotalMoney();
		}

		health -= damageAmount;
		if (health <= 0)
		{
			health = 0;
			gameObject.SetActive(false);
		}
	}
	private IEnumerator SpawnButtonCorutine(GameObject other)
	{

		animator.Play("Fight");
		yield return new WaitForSeconds(0.5f);
		
	}
	private void WinAnimations()
	{
		animator.Play("Happy");
	}

	private void DieAnimation()
	{
		animator.Play("Die");
	}

}
