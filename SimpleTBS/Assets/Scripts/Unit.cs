using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
	public HexLoc loc;
	public bool isAI = false;
	public int moveRange = 5;
	public Dictionary<HexLoc, List<UnitAction>> possibleActions = new Dictionary<HexLoc, List<UnitAction>>();

	public void CalcActions()
	{

	}
}
