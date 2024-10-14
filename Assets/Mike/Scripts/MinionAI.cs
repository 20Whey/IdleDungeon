using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinionAI : MonoBehaviour
{
	private enum State
	{
		Roaming,
		ChaseTarget,
		Attacking,
	}
	private CharacterPathfindingHandler pathfindingHandler;
	private Vector2 startingPosition;
	private Vector2 wanderPosition;
	private GameObject targetAdventurer;
	private State state;
	private Rigidbody2D rb;


	private void Awake()
	{
		pathfindingHandler = GetComponent<CharacterPathfindingHandler>();
		rb = GetComponent<Rigidbody2D>();
		state = State.Roaming;
	}

	private void Start()
	{
		startingPosition = transform.position;
		wanderPosition = GetWanderPosition();
	}

	private void Update()
	{
		switch (state)
		{
		default:
			case State.Roaming:
				pathfindingHandler.SetTargetPosition(wanderPosition);

				if (Vector2.Distance(transform.position, wanderPosition) < 1f)
				{
					//reached current wander pos
					wanderPosition = GetWanderPosition();
				}

				break;

			case State.ChaseTarget:
				pathfindingHandler.SetTargetPosition(targetAdventurer.transform.position);

				float attackRange = 1f;
				if((Vector2.Distance(transform.position, targetAdventurer.transform.position) < attackRange))
				{
					//state = State.Attacking;
				}
				break;
			case State.Attacking:
				break;
		}
	}
	private Vector2 GetWanderPosition()
	{
		Vector2 randomDirection;
		//random X/Y direction
		randomDirection = new Vector2(UnityEngine.Random.Range(-1f, 1f), UnityEngine.Random.Range(-1f, 1f)).normalized;

		return startingPosition + randomDirection * Random.Range(1.5f, 2f);
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.tag == "Adventurer")
		{
			state = State.ChaseTarget;
			targetAdventurer = collision.gameObject;
		}
	}
}
