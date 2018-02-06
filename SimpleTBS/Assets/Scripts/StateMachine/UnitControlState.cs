using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitControlState : State
{
	public override void Activate()
	{
		SelectActiveUnit();
		UnitController.Instance.init[0].CalcActions();
	}

	void SelectActiveUnit()
	{
		if (!GameObject.Find("Selector"))
		{
			GameObject s = Instantiate(Resources.Load("Selector")) as GameObject;
			s.name = "Selector";

		}
		Selector.Instance.SetLocation(Room.Instance.GetTile(UnitController.Instance.init[0].loc));
		CameraControl.Instance.FocusCam(UnitController.Instance.init[0].loc);
		Selector.Instance.u = UnitController.Instance.init[0];
	}
}
