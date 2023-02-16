using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierPool : MonoBehaviour
{
	public Queue<GameObject> soldierPool;
	public Transform target;

	[SerializeField] private GameObject soldierPrefab;
	[SerializeField] private int soldierPoolSize;



	private void Awake()
	{
		soldierPool = new Queue<GameObject>();


		for (int i = 0; i < soldierPoolSize; i++)
		{
			GameObject soldierGO = Instantiate(soldierPrefab);

			soldierGO.SetActive(false);

			soldierPool.Enqueue(soldierGO);

			soldierGO.transform.parent = transform;
		}
	}

	public GameObject GetSoldierFromPool()
	{
		GameObject firstSoldier = soldierPool.Dequeue();

		firstSoldier.SetActive(true);

		soldierPool.Enqueue(firstSoldier);

		return firstSoldier;
	}


}
