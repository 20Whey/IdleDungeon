using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GoldManager : MonoBehaviour
{
	public static GoldManager instance { get; private set; }

	public TMP_Text goldText;
	private int goldCount = 0;

	private void Awake()
	{
		instance = this; 
	}

	private void Start()
	{
		goldText.text = goldCount.ToString();
	}

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Keypad8))
		{
			IncreaseGold(1000);
		}

		if (Input.GetKeyDown(KeyCode.Keypad2))
		{
			DecreaseGold(1000);
		}
	}

	public void IncreaseGold(int gold)
	{
		goldCount += gold;
		goldText.text = goldCount.ToString();
	}
	public void DecreaseGold(int gold)
	{
		goldCount -= gold;
		goldText.text = goldCount.ToString();
	}

}
