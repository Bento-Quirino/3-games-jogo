using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/// <summary>
/// Add this component to a TextMeshPro object to make it run a typewriting
/// </summary>
[RequireComponent(typeof(TextMeshProUGUI))]
public class TypeWriter : MonoBehaviour
{
	TextMeshProUGUI box;

	Coroutine routine;
	Action OnEndWrting; // End of writing callback

	WaitForSeconds letterWait;
	[SerializeField] float letterDelay;

	string lastDialogue;

	public bool typing {  get; private set; }

	private void Start()
	{
		typing = false;
		letterWait = new WaitForSeconds(letterDelay);
		box = GetComponent<TextMeshProUGUI>();
	}

	/// <summary>
	/// Add function to run on the end of writing
	/// </summary>
	/// <param name="observer"></param>
	public void AddObserver(Action observer)
	{
		RemoveObserver(observer);
		OnEndWrting += observer;
	}

	/// <summary>
	/// Remove a observer function
	/// </summary>
	/// <param name="observer"></param>
	public void RemoveObserver(Action observer)
	{
		OnEndWrting -= observer;
	}

	/// <summary>
	/// Start a new writing
	/// </summary>
	/// <param name="dialogue"></param>
	public void TypeWrite(string dialogue)
	{
		if(typing) { return; }

		lastDialogue = dialogue;
		routine = StartCoroutine(Typing(dialogue));
	}

	/// <summary>
	/// Force end of current writing. Display all text at once.
	/// </summary>
	public void End()
	{
		if(!typing) { return; }

		StopCoroutine(routine);

		box.text = lastDialogue;
		typing = false;

		OnEndWrting?.Invoke();
	}

	IEnumerator Typing(string text)
	{
		box.text = "";
		typing = true;

		for (int i = 0; i < text.Length; i++)
		{
			box.text += text[i];
			yield return letterWait;
		}

		typing = false;

		OnEndWrting?.Invoke();
	}
}