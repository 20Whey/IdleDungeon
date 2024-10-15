using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Adventurer : MonoBehaviour
{
	[SerializeField] private int currentHeldGold;
	static int maxHeldGold = 30;
	private CharacterPathfindingHandler pathfindingHandler;
	private Rigidbody2D rb;
	private int health = 10;
	public float distanceFrom;
	[SerializeField] private GameObject targetTreasure;
	private bool isStealing;


	private void Awake()
	{
		pathfindingHandler = GetComponent<CharacterPathfindingHandler>();
		rb = GetComponent<Rigidbody2D>();

		GoToClosestTreasure();

    }
	private void Update()
	{
		//PathfindToThing
	}

	void FixedUpdate()
	{
		
		if (IsItemCloseEnough(0.5f, gameObject, targetTreasure))
		{
			if(!isStealing)StartStealing();
            //Steal(targetTreasure, counter);
            // force change Adventurer state and pathfind to exit
			
        }
		else
		{
			StopStealing();
		}
		
		
	}

	 
	public void TakeDamage(int damage)
	{
		health -= damage;
		Debug.Log("OW my health is " + health);
	}

	private bool IsItemCloseEnough(float pickupRange, params GameObject[] things)
	{ 
		//Hyjacking your code, apologies
		distanceFrom = Vector3.Distance(things[0].transform.position, things[1].transform.position);
		if (pickupRange > distanceFrom) return true; 
		return false;
	}

	public void StopStealing()
	{
		CancelInvoke("Steal");
	}
	public void StartStealing()
	{
		InvokeRepeating("Steal", 0.4f, 0.4f);
	}
	private void Steal()
	{
	//isStealing = true;
	currentHeldGold += 5;
	Debug.Log("Stealing treasure");	
	}

	public GameObject FindClosestTreasure()
	{

	}
	public Position ReturnTargetPosition()
	{

	}
	public void GoTo()
	{

		targetTreasure = TreasureManager.instance.GetClosestTreasure(gameObject);
		//if (targetTreasure != null)
		//comparison to null isn't actually required and takes more resource
		if (targetTreasure)
		{
			pathfindingHandler.SetTargetPosition(targetTreasure.transform.position);
		}
	}
	
}
