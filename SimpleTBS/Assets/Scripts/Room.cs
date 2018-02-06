using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
	public Dictionary<HexLoc, HexTile> locs = new Dictionary<HexLoc, HexTile>();
	public Dictionary<HexLoc, GameObject> occupiedTiles = new Dictionary<HexLoc, GameObject>();

	public static Room Instance;
	private void Awake()
	{
		Instance = this;
	}

	public void Load()
	{
		int radius = 7;

		if (radius > 0)
		{
			AddLoc(new HexLoc(0, 0));
			for (int fRadius = 1; fRadius <= radius; fRadius++)
			{
				//Set initial hex grid location
				HexLoc loc = new HexLoc(fRadius, -fRadius);
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
		int randHeight = Random.Range(0, 3);
		int yRot = Random.Range(0, 6) * 60;
		Quaternion rot = Quaternion.Euler(0, yRot, 0);
		Vector3 worldLoc = loc.ToWorld() + (Vector3.up * randHeight * 0.25f);
		HexTile t = (Instantiate(Resources.Load("Tile"), worldLoc, rot) as GameObject).GetComponent<HexTile>();
		t.height = randHeight;
		t.transform.parent = transform;
		t.loc = loc;
		locs.Add(loc, t);
		for(int i = randHeight - 1; i >= 0; i--)
		{
			HexLoc newLoc = loc;
			Vector3 worldLoc2 = newLoc.ToWorld() + (Vector3.up * i * 0.25f);
			GameObject nt = Instantiate(Resources.Load("TileBlank"), worldLoc2, Quaternion.identity) as GameObject;
			nt.transform.parent = t.transform;
		}
	}

	public void AddObject(HexLoc h, GameObject o)
	{
		occupiedTiles.Add(h, o);
	}

	public HexTile GetTile(HexLoc h)
	{
		return (locs.ContainsKey(h) ? locs[h] : null);
	}
}
