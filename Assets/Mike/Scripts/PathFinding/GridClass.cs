using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridClass<TGridObject>
{
	private int width;
	private int height;
	private float cellSize;
	private Vector2 originPosition;
	private TGridObject[,] gridArray;

	public GridClass(int width, int height, float cellSize, Vector2 originPosition, Func<GridClass<TGridObject>, int, int, TGridObject> createGridObject)
	{
		this.width = width;
		this.height = height;
		this.cellSize = cellSize;
		this.originPosition = originPosition;

		gridArray = new TGridObject[width, height];

		for (int x = 0; x < gridArray.GetLength(0); x++) {
			for (int y = 0; y < gridArray.GetLength(1); y++)
			{
				gridArray[x, y] = createGridObject(this, x, y);
			}
		}

		for (int x = 0; x < gridArray.GetLength(0); x++) {
			for (int y = 0; y < gridArray.GetLength(1); y++)
			{
				Debug.DrawLine(XY_ToWorldPos(x, y), XY_ToWorldPos(x, y + 1), Color.white, 100f);
				Debug.DrawLine(XY_ToWorldPos(x, y), XY_ToWorldPos(x + 1, y), Color.white, 100f);
			}
		}
		Debug.DrawLine(XY_ToWorldPos(0, height), XY_ToWorldPos(width, height), Color.white, 100f);
		Debug.DrawLine(XY_ToWorldPos(width, 0), XY_ToWorldPos(width, height), Color.white, 100f);
	}

	public Vector2 XY_ToWorldPos(int x, int y)
	{
		return new Vector2(x, y) * cellSize + originPosition;
	}
	public Vector2Int WorldPosTo_XY(Vector2 worldPos)
	{
		int x = Mathf.FloorToInt((worldPos - originPosition).x / cellSize);
		int y = Mathf.FloorToInt((worldPos - originPosition).y / cellSize);
		return new Vector2Int(x, y);
	}
	public void SetGridObject(int x, int y, TGridObject value)
	{
		//ignoring null coords in grid
		if(x >= 0 && y >= 0 && x < width && y < height)
		{
			gridArray[x, y] = value;
		}
	}
	public void SetGridObject(Vector2 worldPosition, TGridObject value)
	{
		Vector2Int intPos;
		intPos = WorldPosTo_XY(worldPosition);
		SetGridObject(intPos.x, intPos.y, value);
	}
	public TGridObject GetGridObject(int x, int y)
	{
		//ignoring null coords in grid
		if (x >= 0 && y >= 0 && x < width && y < height)
		{
			return gridArray[x, y];
		}
		else
		{
			return default(TGridObject);
		}
	}
	public TGridObject GetGridObject(Vector2 worldPosition)
	{
		Vector2Int intPos;
		intPos = WorldPosTo_XY(worldPosition);
		return GetGridObject(intPos.x, intPos.y);
	}
	public int GetWidth() {
		return width;
	}
	public int GetHeight() {
		return height;
	}
	public float GetCellSize() {
		return cellSize;
	}
}
