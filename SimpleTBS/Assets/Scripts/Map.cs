using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
	List<Room> rooms = new List<Room>();
	public int radius;

	public void GenMap()
	{
		if (radius > 0)
		{
			AddRoom(new HexLoc(0, 0, 0));
			for (int fRadius = 1; fRadius <= radius; fRadius++)
			{
				//Set initial hex grid location
				HexLoc loc = new HexLoc(fRadius, -fRadius, 0);

				HexDir dir = (HexDir)2;
				//Find data for each hex in the ring (each ring has 6 more hexes than the last)
				for (int fHex = 0; fHex < 6 * fRadius; fHex++)
				{
					Debug.Log(loc.ToWorld());
					AddRoom(loc);
					//Finds next hex in ring
					loc = loc.MoveTo(dir);
					if (loc.x == 0 || loc.y == 0 || loc.x == -loc.y)
					{
						dir++;
					}
				}
			}
		}
	}

	Room AddRoom(HexLoc h)
	{
		Room r = (Instantiate(Resources.Load("Room")) as GameObject).GetComponent<Room>();
		r.loc = h;
		r.transform.position = h.ToWorld();
		return r;
	}
}
