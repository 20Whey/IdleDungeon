using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterPathfindingHandler : MonoBehaviour
{
    private const float speed = 10f;

    private int currentPathIndex;
    private List<Vector2> pathVectorList;

	private void Start()
	{
		
	}
	private void Update()
	{
		HandleMovement();
	}

	private void HandleMovement()
	{
		if (pathVectorList != null)
		{
			Vector2 targetPosition = pathVectorList[currentPathIndex];
			if (Vector2.Distance(transform.position, targetPosition) > 1f)
			{
				Vector2 moveDirection = (targetPosition - (Vector2)transform.position).normalized;

				float previousDistance = Vector2.Distance(transform.position, targetPosition);
				transform.position = (Vector2)transform.position + moveDirection * speed * Time.deltaTime;
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

		if (pathVectorList != null && pathVectorList.Count > 1)
		{
			pathVectorList.RemoveAt(0);
		}
	}
}
