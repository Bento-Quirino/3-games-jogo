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
		StartCoroutine(FadeOut());
	}

	public void Update()
	{
		if(pause) { return; }

		eventManager.Process();
	}

	public override IEnumerator OnExitIntervaled()
	{
		pause = true;
		yield return null;
	}

	IEnumerator FadeOut()
	{
		eventManager.Init();
		fade.Out();
		yield return null;
	}
}