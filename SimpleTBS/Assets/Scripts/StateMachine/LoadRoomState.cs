using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadRoomState : State
{
	public override void Activate()
	{
		Map.instance.currentRoom.Load();
	}
}
