using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAction : UnitAction
{
	public override List<HexTile> CalcPossibleActions()
	{
		List<HexTile> retValue = new List<HexTile>();
		Queue<HexTile> checkNext = new Queue<HexTile>();
		Queue<HexTile> checkNow = new Queue<HexTile>();

		checkNow.Enqueue(Room.Instance.locs[GetComponent<Unit>().loc]);

		while(checkNow.Count > 0)
		{
			HexTile t = checkNow.Dequeue();
			for(int i = 0; i < 6; i++)
			{
				HexTile next = Room.Instance.GetTile(t.loc.MoveTo(i));
				if (next == null)
					continue;
				if()
			}
		}

		return retValue;
	}
}
