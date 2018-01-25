using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
	public State state;

	public void ChangeState<T> () where T : State
	{
		if(state != null)
			state.enabled = false;
		T s = GetComponent<T>();
		if (s == null)
			s = gameObject.AddComponent<T>();
		state = s;
		state.Activate();
	}

	private void Awake()
	{
		ChangeState<LoadMainMenuState>();
	}
}
