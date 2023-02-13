using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class House : MonoBehaviour
{
    void Update()
    {
		//StartCoroutine(ProduceSoldierCorutine());
    }
	private void OnMouseDown()
	{
		
	}
	private void ProduceSoldier()
	{
	}

	private IEnumerator ProduceSoldierCorutine(float time)
	{
		yield return new WaitForSeconds(time);
	}

	private void UpdateHouse()
	{

	}

	private void SetProduceAnimation()
	{

	}
}
