using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
	public HexLoc loc;
	public List<HexLoc> connections = new List<HexLoc>();
	public Dictionary<HexLoc, HexTile> locs = new Dictionary<HexLoc, HexTile>();

	public void FindConnections()
	{
		for(int i = 0; i < 6; i++)
		{
			HexLoc h = loc.MoveTo((HexDir)i);
			if (Map.instance.rooms.ContainsKey(h))
				connections.Add(h);
		}
	}

	public void Load()
	{
		int radius = Random.Range(3, 7);

		if (radius > 0)
		{
			AddLoc(new HexLoc(0, 0, 0));
			for (int fRadius = 1; fRadius <= radius; fRadius++)
			{
				//Set initial hex grid location
				HexLoc loc = new HexLoc(fRadius, -fRadius, 0);
				HexDir dir = (HexDir)2;
				//Find data for each hex in the ring (each ring has 6 more hexes than the last)
				for (int fHex = 0; fHex < 6 * fRadius; fHex++)
				{
					AddLoc(loc);
					//Finds next hex in ring
					loc = loc.MoveTo(dir);
					if (loc.x == 0 || loc.y == 0 || loc.x == -loc.y)
					{
						dir++;
					}
				}
			}
		}
		foreach (HexTile t in locs.Values)
		{
			t.FindConnections();
		}

	}

	void AddLoc(HexLoc loc)
	{
		int randHeight = Random.Range(0, 5);
		int yRot = Random.Range(0, 6) * 60;
		int xRot = Random.Range(0, 2) * 180;
		Quaternion rot = Quaternion.Euler(xRot, yRot, 0);
		loc.h = randHeight;
		HexTile t = (Instantiate(Resources.Load("Tile"), loc.ToWorld(), rot) as GameObject).GetComponent<HexTile>();
		t.loc = loc;
		locs.Add(loc, t);
	}
}
