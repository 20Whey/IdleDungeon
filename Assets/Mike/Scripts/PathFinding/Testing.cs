using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Testing : MonoBehaviour
{
	private CharacterPathfindingHandler characterPathfinding;
	public Pathfinding pathfinding;

	private void Start()
	{
		pathfinding = new Pathfinding(90, 50);
		characterPathfinding = FindObjectOfType<CharacterPathfindingHandler>();
	}

	private void Update()
	{
		if (Input.GetMouseButtonDown(0))
		{
			Vector2 mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			characterPathfinding.SetTargetPosition(mouseWorldPosition);
		}
		if (Input.GetMouseButtonDown(1))
		{
			Vector2 mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			Vector2Int mouseXYPosition = pathfinding.GetGrid().WorldPosTo_XY(mouseWorldPosition);
			pathfinding.GetNode(mouseXYPosition.x, mouseXYPosition.y).SetIsWalkable(!pathfinding.GetNode(mouseXYPosition.x, mouseXYPosition.y).isWalkable);
		}
	}
}
 