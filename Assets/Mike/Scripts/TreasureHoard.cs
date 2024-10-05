using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreasureHoard : MonoBehaviour
{
	int goldIncreaseRate = 10;

	private void Start()
	{
		TreasureManager.instance.AddTreasureToList(gameObject);
		InvokeRepeating("GoldTick", 1f, 3f);
	}

	private void GoldTick()
	{
		GoldManager.instance.IncreaseGold(goldIncreaseRate);
	}
}
