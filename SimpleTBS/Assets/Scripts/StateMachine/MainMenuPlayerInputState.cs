using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuPlayerInputState : State
{
	public override void Activate()
	{
		GameObject.Find("NewGameButton").GetComponent<Button>().onClick.AddListener(NewGame);
	}

	public void NewGame()
	{
		GetComponent<StateMachine>().ChangeState<LoadNewGameState>();
	}

}
