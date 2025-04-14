using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utility.FSM;

public class StageStart : AbstractState
{
	[SerializeField] UIFader fade;

	public override IEnumerator OnEnterIntervaled()
	{
		// Use this state to start something
		yield return null;
		machine.ChangeStateCoroutine<StageUpdate>();
	}
}
