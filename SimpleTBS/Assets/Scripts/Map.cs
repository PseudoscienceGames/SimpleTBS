using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
	public Dictionary<HexLoc, Room> rooms = new Dictionary<HexLoc, Room>();
	public int radius;
	public Room currentRoom;

	public static Map instance;
	private void Awake() { instance = this; }

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
		foreach(Room r in rooms.Values)
		{
			r.FindConnections();
		}
		List<Room> locs = new List<Room>(rooms.Values);
		currentRoom = locs[Random.Range(0, rooms.Count - 1)];
	}

	Room AddRoom(HexLoc h)
	{
		Room r = (Instantiate(Resources.Load("Room")) as GameObject).GetComponent<Room>();
		r.loc = h;
		r.transform.position = h.ToWorld();
		rooms.Add(h, r);
		return r;
	}
}
