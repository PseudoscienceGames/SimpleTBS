﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct HexLoc
{
	public int x;
	public int y;
	public int z;

	public HexLoc(int x, int y)
	{
		this.x = x;
		this.y = y;
		z = (int)(0 - (x + y));
	}

	public Vector3 ToWorld()
	{
		Vector3 worldPos = new Vector3((y - z) / 2f, 0, x * (Mathf.Sqrt(3) / 2f));
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
		HexLoc moveTo = new HexLoc(this.x, this.y);
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
		moveTo.z = (int)(0 - (moveTo.x + moveTo.y));
		return moveTo;
	}

	public override string ToString()
	{
		return "(" + x + ", " + y + ", " + z + ")";
	}
}
