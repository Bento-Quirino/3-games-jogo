using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
	[SerializeField] StageEvent[] events;
	[SerializeField] EventLoader loader;

	int current;

	public void Init()
	{
		current = 0;
		Next(current);
	}

	public void Process()
	{
		if (Input.GetButtonDown("Fire1"))
		{
			if (loader.typeWriter.typing)
			{ loader.typeWriter.End(); return; }

			Next(current++);
		}
	}

	public void Next(int index)
	{
		StageEvent ev = events[index];
		loader.Load(ev);
	}
}