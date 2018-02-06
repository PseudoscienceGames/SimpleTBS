using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAction : UnitAction
{
	private void Awake()
	{
		actionName = "Move";
	}

	public override List<HexTile> CalcPossibleActions()
	{
		List<HexTile> retValue = new List<HexTile>();
		//Queue<Node> checkNext = new Queue<Node>();
		Queue<Node> checkNow = new Queue<Node>();

		checkNow.Enqueue(new Node(Room.Instance.locs[GetComponent<Unit>().loc], 0));

		while(checkNow.Count > 0)
		{
			Node n = checkNow.Dequeue();
			foreach(HexTile h in n.h.connections)
			{
				int cost;
				if (Mathf.Abs(n.h.height - h.height) <= 1)
					cost = 1 + n.cost;
				else
					cost = Mathf.Abs(n.h.height - h.height) + n.cost;
				if (cost <= GetComponent<Unit>().moveRange)
				{
					if (!retValue.Contains(h) && !Room.Instance.occupiedTiles.ContainsKey(h.loc))
					{
						checkNow.Enqueue(new Node(h, cost));
						retValue.Add(h);
					}
				}
			}

		}
		Debug.Log(retValue.Count);
		return retValue;
	}

	public override void Act(HexTile h)
	{
		transform.position = h.WorldLoc();
		Room.Instance.occupiedTiles.Remove(GetComponent<Unit>().loc);
		GetComponent<Unit>().loc = h.loc;
		Room.Instance.occupiedTiles.Add(GetComponent<Unit>().loc, gameObject);
		base.Act(h);
	}
}
