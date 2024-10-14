using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Adventurer : MonoBehaviour
{
	private CharacterPathfindingHandler pathfindingHandler;
	private Rigidbody2D rb;
	private int health = 10;
	[SerializeField] private GameObject targetTreasure;

	private void Awake()
	{
		pathfindingHandler = GetComponent<CharacterPathfindingHandler>();
		rb = GetComponent<Rigidbody2D>();
	}
	private void Update()
	{
		targetTreasure = TreasureManager.instance.GetClosestTreasure(gameObject);
		if (targetTreasure != null)
		{
			pathfindingHandler.SetTargetPosition(targetTreasure.transform.position);
		}
	}

	public void TakeDamage(int damage)
	{
		health -= damage;
		Debug.Log("OW my health is " + health);
	}
}
