using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
	[SerializeField] StageEvent[] events;
	[SerializeField] StageLoader loader;

	int current;

	private void Start()
	{
		loader.AddObserver(OnEventEnd);
	}

	public void Next(int index)
	{
		StageEvent ev = events[index];
		loader.Load(ev);
	}

	void OnEventEnd()
	{
		Next(current++);
	}

	private void OnDisable()
	{
		loader.RemoveObserver(OnEventEnd);
	}
}