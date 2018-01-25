using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
	public HexLoc loc;

	public Room(HexLoc loc)
	{
		this.loc = loc;
	}
}
