using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Testing : MonoBehaviour
{
	private CharacterPathfindingHandler characterPathfinding;
	private Pathfinding pathfinding;

	private void Start()
	{
		pathfinding = new Pathfinding(10, 10);
		characterPathfinding = FindObjectOfType<CharacterPathfindingHandler>();
	}

	private void Update()
	{
		if (Input.GetMouseButtonDown(0))
		{
			Vector2 mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			Vector2Int mouseXYPosition = pathfinding.GetGrid().WorldPosTo_XY(mouseWorldPosition);
			Debug.Log(mouseXYPosition.x + " " + mouseXYPosition.y);
			List<PathNode> path = pathfinding.FindPath(0, 0, mouseXYPosition.x, mouseXYPosition.y);
			if (path != null)
			{
				for (int i = 0; i < path.Count - 1; i++)
				{
					Debug.Log(path[i].x + " " + path[i].y);
					Debug.DrawLine(new Vector2(path[i].x, path[i].y) * 1f + Vector2.one * 1f, new Vector2(path[i + 1].x, path[i + 1].y) * 1f + Vector2.one * 1f, Color.green, 20f);
				}
			}
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
 