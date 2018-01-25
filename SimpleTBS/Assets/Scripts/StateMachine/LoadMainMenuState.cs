using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadMainMenuState : State
{
	public override void Activate()
	{
		GameObject mm = Instantiate(Resources.Load("MainMenu")) as GameObject;
		mm.name = "MainMenu";
		GetComponent<StateMachine>().ChangeState<MainMenuPlayerInputState>();
	}
}
