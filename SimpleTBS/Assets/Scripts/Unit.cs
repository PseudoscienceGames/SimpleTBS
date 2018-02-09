using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
	public HexLoc loc;

	public int maxHP;
	public int currentHP;

	public bool isAI = false;
	public int moveRange = 3;
	public Dictionary<HexTile, List<UnitAction>> possibleActions = new Dictionary<HexTile, List<UnitAction>>();

	public void CalcActions()
	{
		possibleActions.Clear();
		foreach(UnitAction a in GetComponents<UnitAction>())
		{
			List<HexTile> hs = a.CalcPossibleActions();
			foreach (HexTile h in hs)
			{
				if (!possibleActions.ContainsKey(h))
					possibleActions.Add(h, new List<UnitAction>());
				possibleActions[h].Add(a);
			}
		}
		ShowPossibleActions();
	}

	void ShowPossibleActions()
	{
		foreach(HexTile h in possibleActions.Keys)
		{
			GameObject currentMarker = Instantiate(Resources.Load("TileMarker"), h.WorldLoc(), Quaternion.identity) as GameObject;
			currentMarker.GetComponent<TileMarker>().t = h;
			currentMarker.transform.parent = Selector.Instance.transform;
		}
	}
}
