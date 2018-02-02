using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadNewGameState : State
{
	public override void Activate()
	{
		GameObject.Find("MainMenu").SetActive(false);
		Instantiate(Resources.Load("Room"));
		GetComponent<StateMachine>().ChangeState<LoadRoomState>();
	}
}
