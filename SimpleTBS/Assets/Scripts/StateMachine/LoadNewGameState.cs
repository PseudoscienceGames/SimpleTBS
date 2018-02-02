using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadNewGameState : State
{
	public override void Activate()
	{
		GameObject.Find("MainMenu").SetActive(false);
		Instantiate(Resources.Load("Room"));
		Room.Instance.Load();
		Instantiate(Resources.Load("UnitController"));
		UnitController.Instance.AddUnits();
		if(UnitController.Instance.init[0].isAI)
			GetComponent<StateMachine>().ChangeState<CompUnitControlState>();
		else
			GetComponent<StateMachine>().ChangeState<PlayerUnitControlState>();
	}
}
