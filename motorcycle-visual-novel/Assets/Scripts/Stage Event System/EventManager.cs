using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
	// Callback para rodar funções do StateManager
	Action<float> OnTransition;
	Action OnEnd;

	[SerializeField] StageEvent[] events;
	[SerializeField] EventLoader loader;

	// Pausa o input do jogador para carregar conteúdo
	public bool processing {  get; private set; }

	int current;

	public void Init(Action<float> transition, Action end)
	{
		current = 0;
		loader.Load(events[current]);
		processing = false;

		OnTransition += transition;
		OnEnd += end;
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
		if (processing) { return; }
		processing = true;

		if (current > events.Length)
		{
			OnEnd();
			return;
		}

		StartCoroutine(Processing(index));
	}

	IEnumerator Processing(int index)
	{
		StageEvent ev = events[index];
		if(ev.transition)
		{
			OnTransition(2f);
			yield return new WaitForSeconds(1f);
			loader.Load(ev);
			yield return new WaitForSeconds(1f);
		}

		processing = false;
	}

	private void OnDisable()
	{
		OnTransition = null;
		OnEnd = null;
	}
}