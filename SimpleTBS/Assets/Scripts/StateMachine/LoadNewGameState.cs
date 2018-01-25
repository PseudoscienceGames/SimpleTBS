using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadNewGameState : State
{
	public override void Activate()
	{
		GameObject.Find("MainMenu").SetActive(false);
		Map map = (Instantiate(Resources.Load("Map")) as GameObject).GetComponent<Map>();
		map.GenMap();
		GetComponent<StateMachine>().ChangeState<LoadRoomState>();
	}
}
