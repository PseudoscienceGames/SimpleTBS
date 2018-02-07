using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUnitControlState : UnitControlState
{
	public override void Activate()
	{
		base.Activate();

	}

	private void Update()
	{
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;
		if (Input.GetMouseButtonDown(0))
		{
			if (Physics.Raycast(ray, out hit))
			{
				if (ActionMenu.Instance == null)
					Instantiate(Resources.Load("ActionMenuCanvas"));
				ActionMenu.Instance.Activate(hit.transform.GetComponent<TileMarker>().t);
				StateMachine.Instance.ChangeState<PlayerUnitControlHexSelectedState>();
			}
		}
	}
}
