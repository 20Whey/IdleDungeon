using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterPathfindingHandler : MonoBehaviour
{
    private const float speed = 2f;

    private int currentPathIndex;
    private List<Vector2> pathVectorList;
	[SerializeField] private Vector2 characterXYPosition;
	private Vector2 targetWorldPosition;
	public bool isMoving = false;
	public bool isMovingRight = true;

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
			targetWorldPosition = Pathfinding.Instance.GetGrid().XY_ToWorldPos(targetPosition.x, targetPosition.y);

			if (Vector2.Distance(transform.position, targetWorldPosition) > 0.1f)
			{
				isMoving = true;
				transform.position = Vector2.MoveTowards(transform.position, targetWorldPosition, speed * Time.deltaTime);
			}
			else
			{
				currentPathIndex++;
				if (currentPathIndex >= pathVectorList.Count)
				{
					StopMoving();
					isMoving = false;
				}
			}
		}
	}

	public void StopMoving()
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

		if (pathVectorList != null && pathVectorList.Count > 1)
		{
			pathVectorList.RemoveAt(0);
			if(pathVectorList[pathVectorList.Count - 1].x >= characterXYPosition.x)
			{
				isMovingRight = true;
			}
			else
			{
				isMovingRight = false;
			}
		}
	}
}
