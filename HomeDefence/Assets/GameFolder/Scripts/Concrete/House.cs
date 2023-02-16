
using UnityEngine;
using DG.Tweening;
using TMPro;
using UnityEngine.UI;

public class House : MonoBehaviour, IDamagable
{
	public bool isEnemy;
	[SerializeField] private HouseType houseType;
	[SerializeField] private TextMeshPro levelText;
	[SerializeField] private Slider healthBar;
	private float health;
	private float damageAmount = 10;
	private bool hasGameFinished = false;



	private void Start()
	{
		GetComponentInChildren<Renderer>().material.color = houseType.houseColor;
		transform.localScale = houseType.houseScale;
		levelText.text = houseType.houseLevel;
		health = houseType.health;
		healthBar.maxValue = 100;
		healthBar.value = healthBar.maxValue;
	}
	private void OnMouseDown()
	{
		UpdateHouse();
	}
	private void UpdateHouse()
	{

	}

	private void SetProduceAnimation()
	{

	}

	private void OnTriggerEnter(Collider other)
	{
		if (!hasGameFinished)
		{
			IDamagable damagable = GetComponent<IDamagable>();
			IDamagable otherDamagable = other.GetComponent<IDamagable>();
			if (damagable != null)
				damagable.OnDamage();
			if (otherDamagable != null)
				otherDamagable.OnDamage();
		}
	}
	public void OnDamage()
	{
		health -= damageAmount;
		healthBar.value -= damageAmount;
		if (health <= 0)
		{
			hasGameFinished = true;
			health = 0;
			gameObject.SetActive(false);
			GameController.Instance.isGamePlayStarted = false;
			if (isEnemy)
			{
				GameController.Instance.Win();
			}
			else
			{
				GameController.Instance.Fail();
			}
		}
	}
}
