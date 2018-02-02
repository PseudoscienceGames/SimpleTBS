using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selector : MonoBehaviour
{
	public static Selector Instance;
	private void Awake()
	{
		Instance = this;
	}

	public void SetLocation(HexLoc h)
	{
		transform.position = h.ToWorld();
	}
}
