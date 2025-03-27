using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour
{
	[SerializeField] StageComposition[] stages;
	[SerializeField] StageLoader loader;

	private void Start()
	{
		loader.Load(stages[0]);
	}
}