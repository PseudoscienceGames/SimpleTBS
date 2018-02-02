using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadRoomState : State
{
	public override void Activate()
	{
		Room.Instance.Load();
	}
}
