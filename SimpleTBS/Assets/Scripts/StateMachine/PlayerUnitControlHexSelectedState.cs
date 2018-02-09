using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUnitControlHexSelectedState : State
{
	private void Update()
	{
		if(Input.GetKeyDown(KeyCode.Escape))
		{
			for (int i = ActionMenu.Instance.transform.childCount; i > 0; i--)
			{
				DestroyImmediate(ActionMenu.Instance.transform.GetChild(i - 1).gameObject);
			}
			DestroyImmediate(Selector.Instance.gameObject);
			GetComponent<StateMachine>().ChangeState<PlayerUnitControlState>();
		}


	}
}
