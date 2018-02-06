using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitAction : MonoBehaviour
{
	public string actionName;

	public virtual List<HexTile> CalcPossibleActions()
	{
		return null;
	}

	public virtual void Act(HexTile h)
	{
		UnitController.Instance.NextUnit();
	}
}

public struct Node
{
	public HexTile h;
	public int cost;

	public Node(HexTile h, int cost)
	{
		this.h = h;
		this.cost = cost;
	}
}
