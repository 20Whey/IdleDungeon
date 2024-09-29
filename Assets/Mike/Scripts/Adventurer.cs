using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Adventurer : MonoBehaviour
{
	private int health = 10;

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if(collision.gameObject.tag == "Minion")
		{
			TakeDamage(1);
		}
	}
	public void TakeDamage(int damage)
	{
		health -= damage;
		Debug.Log("OW my health is " + health);
	}
}
