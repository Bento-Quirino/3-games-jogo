using System.Collections;
using UnityEngine;
using Utility.FSM;

public class StageUpdate : AbstractState
{
	[SerializeField] UIFader fade;
	[SerializeField] EventManager eventManager;

	bool firstEnter;
	bool pause;

	private void Start()
	{
		firstEnter = true;
	}

	public override IEnumerator OnEnterIntervaled()
	{
		if (firstEnter)
		{
			eventManager.Init(StageTransition, End);
			firstEnter = false;
		}

		yield return FadeOut();
		pause = false;
	}

	public void Update()
	{
		if(pause) { return; }

		eventManager.Process();
	}

	public override IEnumerator OnExitIntervaled()
	{
		pause = true;
		yield return FadeIn();
		yield return null;
	}

	void StageTransition(float time)
	{
		StartCoroutine(Transition(time));
	}

	IEnumerator Transition(float time)
	{
		yield return FadeIn();
		yield return new WaitForSeconds(time);
		yield return FadeOut();
	}

	void End()
	{
		//TODO
	}

	IEnumerator FadeIn()
	{
		fade.In();
		yield return new WaitWhile(() => fade.inTransition);
	}

	IEnumerator FadeOut()
	{
		fade.Out();
		yield return new WaitWhile(() => fade.inTransition);
	}
}