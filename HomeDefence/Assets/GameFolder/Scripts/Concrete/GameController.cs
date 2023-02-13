using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
	[SerializeField] private HouseType houseType;
	[SerializeField] private float spawnInterval;
	[SerializeField] private SoldierPool soldierPool = null;
	public Transform[] targetTransform;
	int counter = 0;

	
	private void Start()
	{
		spawnInterval = houseType.intervalSpeed;
		StartCoroutine(SpawnCorutine());
	}
	private IEnumerator SpawnCorutine()
	{
		while (true)
		{
			var soldierPoolObj = soldierPool.GetSoldierFromPool();

			var soldierPoolObj2 = soldierPool.GetSoldierFromPool();

			soldierPoolObj.transform.position = targetTransform[0].position;

			soldierPoolObj2.transform.position = targetTransform[1].position;

			yield return new WaitForSeconds(spawnInterval);
		}
	}
}
