using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct HexLoc
{
	public int x;
	public int y;
	public int z;
	public int h;

	public HexLoc(int x, int y, int h)
	{
		this.x = x;
		this.y = y;
		z = (int)(0 - (x + y));
		this.h = h;
	}

	public Vector3 ToWorld()
	{
		Vector3 worldPos = new Vector3(0.5f * (y - z) * Mathf.Sqrt(3), h, 1.5f * x);
		return worldPos;
	}

	private HexDir MoveDirFix(HexDir dir)
	{
		while ((int)dir > 5)
			dir -= 6;
		while (dir < 0)
			dir += 6;
		return dir;
	}

	public HexLoc MoveTo(HexDir dir)
	{
		dir = MoveDirFix(dir);
		HexLoc moveTo = new HexLoc(this.x, this.y, this.h);
		if ((int)dir == 0)
		{
			moveTo.x++;
			moveTo.y--;
		}
		if ((int)dir == 1)
			moveTo.x++;
		if ((int)dir == 2)
			moveTo.y++;
		if ((int)dir == 3)
		{
			moveTo.x--;
			moveTo.y++;
		}
		if ((int)dir == 4)
			moveTo.x--;
		if ((int)dir == 5)
			moveTo.y--;
		return moveTo;
	}
}
