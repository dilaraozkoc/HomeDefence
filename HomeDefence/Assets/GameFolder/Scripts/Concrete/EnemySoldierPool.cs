using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySoldierPool : MonoBehaviour
{
    public Queue<GameObject> enemySoldierPool;
	public Transform enemyTarget;

	[SerializeField] private GameObject enemySoldierPrefab;
    [SerializeField] private int enemySoldierPoolSize;
	
	private void Awake()
	{
		enemySoldierPool = new Queue<GameObject>();


		for (int i = 0; i < enemySoldierPoolSize; i++)
		{
			GameObject enemySoldierGO = Instantiate(enemySoldierPrefab);

			enemySoldierGO.SetActive(false);

			enemySoldierPool.Enqueue(enemySoldierGO);

			enemySoldierGO.transform.parent = transform;
		}
	}
	public GameObject GetEnemySoldierFromPool()
	{
		GameObject firstSoldier = enemySoldierPool.Dequeue();

		firstSoldier.SetActive(true);

		enemySoldierPool.Enqueue(firstSoldier);

		return firstSoldier;
	}
}
