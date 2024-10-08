using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinding {

	private const int MOVE_STRAIGHT_COST = 10;
	private const int MOVE_DIAGONAL_COST = 14;

	public static Pathfinding Instance { get; private set; }

	private GridClass<PathNode> grid;
	private List<PathNode> openList;
	private List<PathNode> closedList;

	public Pathfinding(int width, int height)
	{
		Instance = this;
		grid = new GridClass<PathNode>(width, height, 1f, new Vector2(-9, -5), (GridClass<PathNode> g, int x, int y) => new PathNode(g, x, y));
	}

	public GridClass<PathNode> GetGrid()
	{
		return grid;
	}

	public List<Vector2> FindPath(Vector2 startWorldPosition, Vector2 endWorldPosition)
	{
		Vector2Int startXYPosition = grid.WorldPosTo_XY(startWorldPosition);
		Vector2Int endXYPosition = grid.WorldPosTo_XY(endWorldPosition);

		int startX = startXYPosition.x;
		int startY = startXYPosition.y;
		int endX = endXYPosition.x;
		int endY = endXYPosition.y;

		List<PathNode> path = FindPath(startX, startY, endX, endY);
		if (path == null) {
			return null;
		}
		else {
			List<Vector2> vectorPath = new List<Vector2>();
			foreach (PathNode pathNode in path)
			{
				vectorPath.Add(new Vector2(pathNode.x, pathNode.y) * grid.GetCellSize() + Vector2.one * grid.GetCellSize() * .5f);
			}
			return vectorPath;
		}
	}
	public List<PathNode> FindPath(int startX, int startY, int endX, int endY)
	{
		PathNode startNode = grid.GetGridObject(startX, startY);
		PathNode endNode = grid.GetGridObject(endX, endY);

		openList = new List<PathNode> { startNode };
		closedList = new List<PathNode>();

		for (int x = 0; x < grid.GetWidth(); x++)
		{
			for (int y = 0; y < grid.GetHeight(); y++)
			{
				PathNode pathNode = grid.GetGridObject(x, y);
				pathNode.gCost = int.MaxValue;
				pathNode.CalculateFCost();
				pathNode.previousNode = null;
			}
		}

		startNode.gCost = 0;
		startNode.hCost = CalculateDistanceCost(startNode, endNode);
		startNode.CalculateFCost();

		while(openList.Count > 0)
		{
			PathNode currentNode = GetLowestFCostNode(openList);
			if(currentNode == endNode)
			{
				return CalculatePath(endNode);
			}

			openList.Remove(currentNode);
			closedList.Add(currentNode);

			foreach (PathNode neighbourNode in GetNeighborList(currentNode)) {
				if (closedList.Contains(neighbourNode)) continue;
				if (!neighbourNode.isWalkable) {
					closedList.Add(neighbourNode);
					continue;
				}

				int tentativeGCost = currentNode.gCost + CalculateDistanceCost(currentNode, neighbourNode);
				if(tentativeGCost < neighbourNode.gCost) {
					neighbourNode.previousNode = currentNode;
					neighbourNode.gCost = tentativeGCost;
					neighbourNode.hCost = CalculateDistanceCost(neighbourNode, endNode);
					neighbourNode.CalculateFCost();

					if(!openList.Contains(neighbourNode)) {
						openList.Add(neighbourNode);
					}
				}
			}
		}
		//out of nodes on the openlist
		return null;
	}

	private List<PathNode> GetNeighborList(PathNode currentNode)
	{
		List<PathNode> neighborList = new List<PathNode>();

		if(currentNode.x - 1 >= 0)
		{
			//left
			neighborList.Add(GetNode(currentNode.x - 1, currentNode.y));
			//bottom left
			if (currentNode.y - 1 >= 0) neighborList.Add(GetNode(currentNode.x - 1, currentNode.y - 1));
			//top left
			if (currentNode.y + 1 < grid.GetHeight()) neighborList.Add(GetNode(currentNode.x - 1, currentNode.y + 1));
		}
		if (currentNode.x + 1 < grid.GetWidth())
		{
			//right
			neighborList.Add(GetNode(currentNode.x + 1, currentNode.y));
			//bottom right
			if (currentNode.y - 1 >= 0) neighborList.Add(GetNode(currentNode.x + 1, currentNode.y - 1));
			//top right
			if (currentNode.y + 1 < grid.GetHeight()) neighborList.Add(GetNode(currentNode.x + 1, currentNode.y + 1));
		}
		//down
		if (currentNode.y - 1 >= 0) neighborList.Add(GetNode(currentNode.x, currentNode.y - 1));
		//up
		if (currentNode.y + 1 < grid.GetHeight()) neighborList.Add(GetNode(currentNode.x, currentNode.y + 1));

		return neighborList;
	}
	public PathNode GetNode(int x, int y)
	{
		return grid.GetGridObject(x, y);
	}

	private List<PathNode> CalculatePath(PathNode endNode)
	{
		List<PathNode> path = new List<PathNode>();
		path.Add(endNode);
		PathNode currentNode = endNode;
		while(currentNode.previousNode != null) {
			path.Add(currentNode.previousNode);
			currentNode = currentNode.previousNode;
		}
		path.Reverse();
		return path;
	}

	private int CalculateDistanceCost(PathNode a, PathNode b)
	{
		int xDistance = Mathf.Abs(a.x - b.x);
		int yDistance = Mathf.Abs(a.y - b.y);
		int remaining = Mathf.Abs(xDistance - yDistance);
		return MOVE_DIAGONAL_COST * Mathf.Min(xDistance, yDistance) + MOVE_STRAIGHT_COST * remaining;
	}

	private PathNode GetLowestFCostNode(List<PathNode> pathNodeList)
	{
		PathNode lowestFCostNode = pathNodeList[0];
		for (int i = 1; i < pathNodeList.Count; i++) {
			if(pathNodeList[i].fCost < lowestFCostNode.fCost)
			{
				lowestFCostNode = pathNodeList[i];
			}
		}
		return lowestFCostNode;
	}
}
