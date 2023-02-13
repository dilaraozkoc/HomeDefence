using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;

public class House : MonoBehaviour
{
	[SerializeField] private HouseType houseType;
	[SerializeField] private TextMeshPro levelText;
	private void Start()
	{
		GetComponentInChildren<Renderer>().material.color = houseType.houseColor;
		transform.localScale = houseType.houseScale;
		levelText.text = houseType.houseLevel;

	}
	void Update()
    {
		//StartCoroutine(ProduceSoldierCorutine());
    }
	private void OnMouseDown()
	{
		
	}
	private void UpdateHouse()
	{

	}

	private void SetProduceAnimation()
	{

	}
}
