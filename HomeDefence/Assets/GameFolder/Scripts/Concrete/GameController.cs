using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
	public static GameController Instance;
	public Transform[] targetTransform;
	public int totalMoney = 0;
	public bool isGamePlayStarted = false;

	[SerializeField] private HouseType houseType;
	[SerializeField] private float spawnInterval;
	[SerializeField] private SoldierPool soldierPool = null;
	[SerializeField] private EnemySoldierPool enemySoldierPool = null;

	private void Awake()
	{
		Instance = this;
	}
	public void StartGameplay()
	{
		isGamePlayStarted = true;
		spawnInterval = houseType.intervalSpeed;
		StartCoroutine(SpawnCorutine());	
	}
	private IEnumerator SpawnCorutine()
	{

		while (true)
		{
			if (isGamePlayStarted)
			{
				var soldierPoolObj = soldierPool.GetSoldierFromPool();

				var soldierPoolObj2 = soldierPool.GetSoldierFromPool();

				var enemySoldierObj1 = enemySoldierPool.GetEnemySoldierFromPool();

				var enemySoldierObj2 = enemySoldierPool.GetEnemySoldierFromPool();

				soldierPoolObj.transform.position = targetTransform[0].position;

				soldierPoolObj2.transform.position = targetTransform[1].position;

				enemySoldierObj1.transform.position = targetTransform[2].position;

				enemySoldierObj2.transform.position = targetTransform[3].position;
			}
			yield return new WaitForSeconds(spawnInterval);

		}

	}

	public void Win()
	{
		UiController.Instance.winScreen.SetActive(true);
	}

	public void Fail()
	{
		UiController.Instance.failScreen.SetActive(true);
	}

	public int GetTotalMoney(int moneyAmount)
	{
		totalMoney += moneyAmount;
		return totalMoney;
	}
	public void RestartGame()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}
}
