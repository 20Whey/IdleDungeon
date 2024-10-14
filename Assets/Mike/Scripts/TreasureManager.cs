using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreasureManager : MonoBehaviour
{
	public static TreasureManager instance { get; private set; }

	public List<GameObject> treasureSources = new List<GameObject>();

	private void Awake()
	{
		instance = this;
	}

	public void AddTreasureToList(GameObject treasurePile)
	{
		treasureSources.Add(treasurePile);
	}

	public GameObject GetClosestTreasure(GameObject adventurer)
	{
		GameObject tMin = null;
		float minDist = Mathf.Infinity;
		Vector2 currentPos = adventurer.transform.position;
		foreach (GameObject treasure in treasureSources)
		{
			float dist = Vector2.Distance(treasure.transform.position, currentPos);
			if (dist < minDist)
			{
				tMin = treasure;
				minDist = dist;
			}
		}
		return tMin;
	}
}
