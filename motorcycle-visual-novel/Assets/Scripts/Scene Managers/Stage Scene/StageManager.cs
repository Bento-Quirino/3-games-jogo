using System.Collections;
using UnityEngine;
using Utility.FSM;

public class StageManager : AbstractMachine
{
	void Start()
	{
		//2s before starting state
		ChangeStateCoroutine<StageStart>(2f);
	}
}