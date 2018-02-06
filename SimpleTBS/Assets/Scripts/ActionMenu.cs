using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActionMenu : MonoBehaviour
{
	public static ActionMenu Instance;
	Vector3 worldPos;

	private void Awake()
	{
		Instance = this;
	}

	private void Update()
	{
		transform.position = Camera.main.WorldToScreenPoint(worldPos);
	}

	public void Activate(HexTile pos)
	{
		foreach(GameObject c in transform)
		worldPos = pos.WorldLoc();
		foreach (UnitAction a in Selector.Instance.u.GetComponents<UnitAction>())
		{
			Transform currentButton = (Instantiate(Resources.Load("ActionButton")) as GameObject).transform;
			currentButton.transform.GetChild(0).GetComponent<Text>().text = a.actionName;
			currentButton.GetComponent<Button>().onClick.AddListener(delegate { a.Act(pos); });
			currentButton.SetParent(transform);
		}
	}
}
