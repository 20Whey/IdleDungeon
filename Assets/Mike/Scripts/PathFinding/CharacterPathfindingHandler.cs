using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterPathfindingHandler : MonoBehaviour
{
    private const float speed = 10f;

    private int currentPathIndex;
    private List<Vector2> pathVectorList;
	private Vector2 characterXYPosition;
	private Vector2 targetWorldPosition;

	private void Update()
	{
		characterXYPosition = Pathfinding.Instance.GetGrid().WorldPosTo_XY(transform.position);
		HandleMovement();
	}
	private void HandleMovement()
	{
		if (pathVectorList != null)
		{
			Vector2 targetPosition = pathVectorList[currentPathIndex];
			if (Vector2.Distance(characterXYPosition, targetPosition) > 0.1f)
			{
				targetWorldPosition = Pathfinding.Instance.GetGrid().XY_ToWorldPos(targetPosition.x, targetPosition.y);
				transform.position = Vector2.MoveTowards(transform.position, targetWorldPosition, speed * Time.deltaTime);
			}
			else
			{
				currentPathIndex++;
				if (currentPathIndex >= pathVectorList.Count)
				{
					StopMoving();
				}
			}
		}
	}

	private void StopMoving()
	{
		pathVectorList = null;
	}
	public Vector2 GetPosition()
	{
		return transform.position;
	}

	public void SetTargetPosition(Vector2 targetPosition)
	{
		currentPathIndex = 0;
		pathVectorList = Pathfinding.Instance.FindPath(GetPosition(), targetPosition);
		foreach (Vector2 vector in pathVectorList)
		{
			Debug.Log("Vector List entry: " + vector);
		}
		if (pathVectorList != null && pathVectorList.Count > 1)
		{
			pathVectorList.RemoveAt(0);
		}
	}
}
