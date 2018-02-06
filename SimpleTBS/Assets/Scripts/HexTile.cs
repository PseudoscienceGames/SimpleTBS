using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexTile : MonoBehaviour
{
	public HexLoc loc;
	public int height;
	public List<HexTile> connections = new List<HexTile>();

	public void FindConnections()
	{
		for (int i = 0; i < 6; i++)
		{
			HexTile h = Room.Instance.GetTile(loc.MoveTo((HexDir)i));
			if(h != null)
				connections.Add(h);
		}
	}

	public Vector3 WorldLoc()
	{
		return loc.ToWorld() + (Vector3.up * height * 0.25f);
	}
}
