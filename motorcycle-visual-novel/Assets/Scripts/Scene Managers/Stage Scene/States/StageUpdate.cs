using System.Collections;
using UnityEngine;
using Utility.FSM;

public class StageUpdate : AbstractState
{
	[SerializeField] UIFader fade;
	[SerializeField] EventManager eventManager;

	bool pause;

	public override IEnumerator OnEnterIntervaled()
	{
		yield return null;
		pause = false;
	}

	public void Update()
	{
		if(pause) { return; }

		eventManager.FrameUpdate();
	}

	public override IEnumerator OnExitIntervaled()
	{
		pause = true;
		yield return null;
	}
}