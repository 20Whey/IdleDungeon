using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathNode {

	private GridClass<PathNode> grid;
	public int x;
	public int y;

	public int gCost;
	public int hCost;
	public int fCost;

	public bool isWalkable;
	public PathNode previousNode;

    public PathNode(GridClass<PathNode> grid, int x, int y)
	{
		this.grid = grid;
		this.x = x;
		this.y = y;
		isWalkable = true;
	}

	public void CalculateFCost()
	{
		fCost = gCost + hCost;
	}

	public void SetIsWalkable(bool isWalkable)
	{
		this.isWalkable = isWalkable;
	}
}
