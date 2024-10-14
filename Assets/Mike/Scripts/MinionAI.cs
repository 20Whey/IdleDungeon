using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinionAI : MonoBehaviour
{
	private enum State
	{
		Idle,
		Roaming,
		ChaseTarget,
		Attacking,
	}
	private CharacterPathfindingHandler pathfindingHandler;
	private Vector2 startingPosition;
	private Vector2 wanderPosition;
	private GameObject targetAdventurer;
	[SerializeField] private State state;
	private Rigidbody2D rb;
	private Animator animator;
	private SpriteRenderer spriteRenderer;
	private bool isIdle = true;
	private const float speed = 1f;


	private void Awake()
	{
		pathfindingHandler = GetComponent<CharacterPathfindingHandler>();
		rb = GetComponent<Rigidbody2D>();
		animator = GetComponent<Animator>();
		spriteRenderer = GetComponentInChildren<SpriteRenderer>();
		state = State.Idle;
	}

	private void Start()
	{
		startingPosition = transform.position;
		wanderPosition = GetWanderPosition();
	}

	private void Update()
	{
		if (pathfindingHandler.isMovingRight == true)
		{
			spriteRenderer.flipX = false;
		}
		else
		{
			spriteRenderer.flipX = true;
		}
		if (pathfindingHandler.isMoving == true)
		{
			animator.ResetTrigger("Idle");
			animator.SetTrigger("Patrolling");
		}
		else
		{
			animator.ResetTrigger("Patrolling");
			animator.SetTrigger("Idle");
		}
		switch (state)
		{
		default:
			case State.Idle:
				if (isIdle == true)
				{
					StartCoroutine(DelayAction());
					state = State.Roaming;
				}
				break;

			case State.Roaming:
				pathfindingHandler.SetTargetPosition(wanderPosition);

				if (Vector2.Distance(transform.position, wanderPosition) < 1f)
				{
					//reached current wander pos
					wanderPosition = GetWanderPosition();
					state = State.Idle;
				}

				break;

			case State.ChaseTarget:
				pathfindingHandler.SetTargetPosition(targetAdventurer.transform.position);

				float attackRange = 1f;
				if((Vector2.Distance(transform.position, targetAdventurer.transform.position) < attackRange))
				{
					state = State.Attacking;
					pathfindingHandler.StopMoving();
				}
				break;
			case State.Attacking:
				Vector2 preAttack = transform.position;
				Vector2 enemyDirection = (targetAdventurer.transform.position - transform.position).normalized;
				Vector2 oppositeEnemyDirection = enemyDirection * -1;

				transform.position = Vector2.MoveTowards(transform.position, enemyDirection * 2f, speed * Time.deltaTime);

				break;
		}
	}
	private Vector2 GetWanderPosition()
	{
		Vector2 randomDirection;
		//random X/Y direction
		randomDirection = new Vector2(UnityEngine.Random.Range(-1f, 1f), UnityEngine.Random.Range(-1f, 1f)).normalized;

		return startingPosition + randomDirection * Random.Range(0.5f, 1f);
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.tag == "Adventurer")
		{
			state = State.ChaseTarget;
			targetAdventurer = collision.gameObject;
		}
	}

	IEnumerator DelayAction()
	{
		isIdle = false;
		yield return new WaitForSeconds(2f);
		isIdle = true;
	}
}
