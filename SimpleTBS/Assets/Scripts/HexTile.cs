using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexTile : MonoBehaviour
{
	public HexLoc loc;
	public List<HexLoc> connections = new List<HexLoc>();

	public void FindConnections()
	{
		for (int i = 0; i < 6; i++)
		{
			HexLoc h = loc.MoveTo((HexDir)i);
			if (Room.Instance.locs.ContainsKey(h))
				connections.Add(h);
		}
	}
}
