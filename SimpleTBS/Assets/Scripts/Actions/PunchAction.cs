using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PunchAction : UnitAction
{
	public int dmg;

	private void Awake()
	{
		actionName = "Punch";
	}

	public override void Act(HexTile h)
	{
		Room.Instance.occupiedTiles[h.loc].GetComponent<Unit>().currentHP -= dmg;
		base.Act(h);
	}

	public override List<HexTile> CalcPossibleActions()
	{
		List<HexTile> retValue = new List<HexTile>();
		foreach (HexTile h in Room.Instance.locs[GetComponent<Unit>().loc].connections)
		{
			if (Room.Instance.occupiedTiles.ContainsKey(h.loc))
				retValue.Add(h);
		}
		return retValue;
	}
}
