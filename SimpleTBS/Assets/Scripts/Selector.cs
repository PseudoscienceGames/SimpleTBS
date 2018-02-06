using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selector : MonoBehaviour
{
	public static Selector Instance;
	public Unit u;
	private void Awake()
	{
		Instance = this;
	}

	public void SetLocation(HexTile h)
	{
		transform.position = h.WorldLoc();
	}
}
