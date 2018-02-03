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
			Instantiate(Resources.Load("Selector"));
		Selector.Instance.SetLocation(UnitController.Instance.init[0].loc);
	}
}
