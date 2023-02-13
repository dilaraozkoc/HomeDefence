using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
	[SerializeField] private float spawnInterval = 1f;
	[SerializeField] private SoldierPool soldierPool = null;
	public Transform[] targetTransform;
	int counter = 0;


	private void Start()
	{
		StartCoroutine(SpawnCorutine());
	}
	private IEnumerator SpawnCorutine()
	{
		
		Debug.Log(counter);
		while (true)
		{
			counter++;
			var soldierPoolObj = soldierPool.GetSoldierFromPool();

			if(counter % 2 == 0)
				soldierPoolObj.transform.position = targetTransform[0].position;
			else
				soldierPoolObj.transform.position = targetTransform[1].position;

			yield return new WaitForSeconds(spawnInterval);
		}
	}
}
