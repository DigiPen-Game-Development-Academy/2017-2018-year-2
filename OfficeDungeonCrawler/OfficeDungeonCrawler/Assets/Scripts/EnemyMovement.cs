/*
Author: Myles Busig
Contributors: Luke T
Date Last Modified: 
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
	// Movement speed of the enemy
	public float speed = 3.0f;
	// Max distance the raycast will search
	public float maxRaycastDistance = 7.5f;

	// Whether or not the enemy can move
	[HideInInspector]
	public bool canMove = true;

	// Target for the enemy will chase
	public GameObject target;

	// The Rigidbody2D component
	new Rigidbody2D rigidbody;
	
	void Start()
	{
		// Get the Rigidbody2D component
		rigidbody = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player");
	}

	void Update()
	{
		// If the target is not set, return
		if (target == null || !canMove)
		{
			rigidbody.velocity = Vector2.zero;
			return;
		}

		// Cast a ray
		RaycastHit2D hit = Physics2D.Raycast(transform.position, target.transform.position - transform.position, maxRaycastDistance);
		
		// Set velocity to zero
		rigidbody.velocity = Vector2.zero;

		// Cast a ray, if something was hit...
		if (hit)
		{
			// If the ray hit the target (If the enemy can see the target)
			if (hit.transform.gameObject == target)
			{
				// Move towards the target
				rigidbody.velocity = (target.transform.position - transform.position).normalized * speed;
			}
			else
			{
				// Stop
				rigidbody.velocity = Vector2.zero;
			}
		}
		else
		{
			// Stop
			rigidbody.velocity = Vector2.zero;
		}

		//Vector2 targetPosition = new Vector2(Mathf.Round(target.transform.position.x), Mathf.Round(target.transform.position.y), target.transform.position.z);
		//Vector2 position = new Vector2(Mathf.Round(transform.position.x), Mathf.Round(transform.position.y), transform.position.z);

		//Tile startTile = new Tile(position);
		//Tile endTile = new Tile(targetPosition);
		//Tile currentTile = startTile;

		//List<Tile> openTiles = new List<Tile>();
		//List<Tile> closedTiles = new List<Tile>();

		//int distanceFromStart = 0;

		//openTiles.Add(startTile);

		//while (openTiles.Count > 0)
		//{
		//	Tile lowestTile = null;
		//	foreach (Tile tile in openTiles)
		//	{
		//		if (lowestTile == null)
		//			lowestTile = tile;
		//		else if (tile.score < lowestTile.score)
		//			lowestTile = tile;
		//	}

		//	closedTiles.Add(lowestTile);
		//	openTiles.Remove(lowestTile);

		//	if (lowestTile == endTile)
		//		break;

		//	List<Tile> adjacentPositions = GetAdjacentPositions(lowestTile.position);

		//	foreach (Tile adjTile in adjacentPositions)
		//	{
		//		foreach (Tile tile in closedTiles)
		//		{
		//			if (tile == adjTile)
		//				continue;
		//		}

		//		bool inOpenTiles = false;
		//		foreach (Tile tile in openTiles)
		//		{
		//			if (tile == adjTile)
		//				inOpenTiles = true;
		//		}

		//		if (inOpenTiles)
		//		{
		//			if (distanceFromStart + adjTile.distanceToTarget < adjTile.score)
		//			{
		//				adjTile.distanceFromStart = distanceFromStart;
		//				adjTile.score = adjTile.distanceFromStart + adjTile.distanceToTarget;
		//				adjTile.parent = currentTile;
		//			}
		//		}
		//		else
		//		{
		//			adjTile.distanceFromStart = distanceFromStart;
		//			adjTile.distanceToTarget = Mathf.RoundToInt(Mathf.Abs(endTile.position.x - adjTile.position.x) + Mathf.Abs(endTile.position.y - adjTile.position.y));
		//			adjTile.score = adjTile.distanceFromStart + adjTile.distanceToTarget;
		//			adjTile.parent = currentTile;

		//			openTiles.Add(adjTile);
		//		}
		//	}
		//}

		//while (currentTile.parent != null)
		//	currentTile = currentTile.parent;

		//Debug.Log("Position: " + currentTile);
	}

	//List<Tile> GetAdjacentPositions(Vector2 position)
	//{
	//	List<Tile> tiles = new List<Tile>();

	//	List<Vector2> positions = new List<Vector2>()
	//	{
	//		position + new Vector2(-1.0f, 0.0f, 0.0f),
	//		position + new Vector2(1.0f, 0.0f, 0.0f),
	//		position + new Vector2(0.0f, -1.0f, 0.0f),
	//		position + new Vector2(0.0f, 1.0f, 0.0f)
	//	};

	//	foreach (Vector2 position_ in positions)
	//	{
	//		if (!Physics.BoxCast(position_, new Vector2(0.5f, 0.5f, 0.5f), Vector2.zero))
	//			tiles.Add(new Tile(position_));
	//	}

	//	return tiles;
	//}

	//class Tile
	//{
	//	public Vector2 position;
	//	public int distanceFromStart;
	//	public int distanceToTarget;
	//	public int score;
	//	public Tile parent;

	//	public Tile(Vector2 position_)
	//	{
	//		position = position_;
	//	}
	//}
}
