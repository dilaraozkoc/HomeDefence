using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soldier : MonoBehaviour
{
	public bool onTouch = false;
	private void Update()
	{
		transform.Translate(Vector3.forward * (Time.deltaTime * 1f));
	}
	private void OnMouseDown()
	{
		onTouch = true;

		gameObject.SetActive(false);

		Debug.Log("Deðdi");
	}
}
