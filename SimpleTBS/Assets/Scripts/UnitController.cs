using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitController : MonoBehaviour
{
	public List<Unit> init = new List<Unit>();
	public List<Unit> playerUnits = new List<Unit>();
	public List<Unit> compUnits = new List<Unit>();

	public static UnitController Instance;
	private void Awake()
	{
		Instance = this;
	}

	public void AddUnits()
	{
		AddPlayerUnits();
		AddComputerUnits();
		CalcInit();
	}
	void AddPlayerUnits()
	{
		for(int i = 1; i <= 3; i++)
		{
			Unit u = (Instantiate(Resources.Load("UnitBlank")) as GameObject).GetComponent<Unit>();
			playerUnits.Add(u);
			HexLoc h = new List<HexLoc>(Room.Instance.locs.Keys)[Random.Range(0, Room.Instance.locs.Count - 1)];
			u.loc = h;
			u.transform.position = Room.Instance.GetTile(u.loc).WorldLoc();
			u.transform.parent = transform;
			Room.Instance.AddObject(h, u.gameObject);
		}
	}

	void AddComputerUnits()
	{
		for (int i = 1; i <= 3; i++)
		{
			Unit u = (Instantiate(Resources.Load("UnitBlank")) as GameObject).GetComponent<Unit>();
			compUnits.Add(u);
			HexLoc h = new List<HexLoc>(Room.Instance.locs.Keys)[Random.Range(0, Room.Instance.locs.Count - 1)];
			u.loc = h;
			u.transform.position = Room.Instance.GetTile(u.loc).WorldLoc();
			u.isAI = true;
			u.transform.parent = transform;
			Room.Instance.AddObject(h, u.gameObject);
		}
	}

	void CalcInit()
	{
		init.AddRange(playerUnits);
		init.AddRange(compUnits);
		//sort by speed
	}

	public void NextUnit()
	{
		Unit u = init[0];
		UnitController.Instance.init.RemoveAt(0);
		UnitController.Instance.init.Add(u);
		for (int i = 0; i < ActionMenu.Instance.transform.childCount; i++)
		{
			DestroyImmediate(ActionMenu.Instance.transform.GetChild(i).gameObject);
		}
		DestroyImmediate(Selector.Instance.gameObject);
		if (UnitController.Instance.init[0].isAI)
			StateMachine.Instance.ChangeState<CompUnitControlState>();
		else
			StateMachine.Instance.ChangeState<PlayerUnitControlState>();
	}
}
